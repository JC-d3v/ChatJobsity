using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebChatApi.Entities;
using System.Security.Cryptography;
using System.Text;
using WebChatApi.Auth;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace WebChatApi.Controllers
{
	public class Encrypt
	{
		public static string GetSHA256(string str)
		{
			SHA256 sha256 = SHA256Managed.Create();
			ASCIIEncoding encoding = new ASCIIEncoding();
			byte[] stream = null;
			StringBuilder sb = new StringBuilder();
			stream = sha256.ComputeHash(encoding.GetBytes(str));
			for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
			return sb.ToString();
		}
	}

	[ApiController]
	[Route("api/users")]
	public class UsersController : ControllerBase
	{
		private readonly ApplicationDbContext context;
		readonly IJwtFactory _jwtFactory;
		readonly JwtIssuerOptions _jwtOptions;

		public UsersController(ApplicationDbContext context, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
		{
			this.context = context;
			_jwtFactory = jwtFactory;
			_jwtOptions = jwtOptions.Value;
		}

		[HttpGet]
		public async Task<ActionResult<List<User>>> Get()
		{
			return await context.Users.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult> Post(User user)
		{
			context.Add(user);
			await context.SaveChangesAsync();
			return Ok();
		}
		[HttpPost("login")]
		public async Task<ActionResult> Login([FromBody] User user)
		{
			var userLogged = await GetClaimsUser(user.Email, user.Password);

			if (userLogged == null)
			{
				return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
			}

			var jwt = await Tokens.GenerateJwt(userLogged, _jwtFactory, userLogged.Name, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });

			return new OkObjectResult(jwt);
		}

		private async Task<ClaimsIdentity> GetClaimsUser(string email, string password)
		{
			if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
				return await Task.FromResult<ClaimsIdentity>(null);
			User user = null;
			try
			{
				user = context.Users
					.Where(c => c.Email == email && c.Password == password )
					.FirstOrDefault();
			}
			catch (Exception ex)
			{
				return await Task.FromResult<ClaimsIdentity>(null);
			}
			var listClaimRoles = new List<Claim>();

			if (user != null)
			{
				return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(email, user.UserId.ToString()));
			}

			return await Task.FromResult<ClaimsIdentity>(null);
		}

	}
}

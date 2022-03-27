using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebChatApi.Entities;
using System.Security.Cryptography;
using System.Text;


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

		public UsersController(ApplicationDbContext context)
		{
			this.context = context;
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

	}
}

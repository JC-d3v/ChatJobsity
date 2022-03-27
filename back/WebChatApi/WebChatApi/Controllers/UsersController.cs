using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebChatApi.Entidades;
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
	[Route("api/usuarios")]
	public class UsersController : ControllerBase
	{
		private readonly ApplicationDbContext context;

		public UsersController(ApplicationDbContext context)
		{
			this.context = context;
		}

		//[HttpGet("{uid:int}")]
		//public async Task<ActionResult<List<Usuario>>> Get(string uid)
		//{
		//	return await context.Usuarios.FirstOrDefaultAsync(x => x.Nombre == uid);
		//}

		[HttpGet]
		public async Task<ActionResult<List<Usuario>>> Get()
		{
			return await context.Usuarios.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult> Post(Usuario usuario)
		{
			context.Add(usuario);
			await context.SaveChangesAsync();
			return Ok();
		}

	}
}

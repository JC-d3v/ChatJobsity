using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebChatApi.Entidades;

namespace WebChatApi.Controllers
{
	[ApiController]
	[Route("api/mensajes")]
	public class MensajesController : ControllerBase
	{
		private readonly ApplicationDbContext context;

		public MensajesController(ApplicationDbContext context)
		{
			this.context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<Mensaje>>> Get()
		{
			return await context.Mensajes.ToListAsync();
		}
		[HttpPost]
		public async Task<ActionResult> Post(Mensaje mensaje)
		{
			//TODO: The stock command won’t be saved on the database as a post.
			//if (mensaje.MensajeChat.Contains("/stock"))
			//{
			//	Console.WriteLine("Llamar Bot");
			//}
			//else
			{
				context.Add(mensaje);

				await context.SaveChangesAsync();
				return Ok();
			}
		}
	}
}

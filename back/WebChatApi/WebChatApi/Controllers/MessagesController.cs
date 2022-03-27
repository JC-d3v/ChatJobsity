using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebChatApi.Entities;

namespace WebChatApi.Controllers
{
	[ApiController]
	[Route("api/messages")]
	public class MessagesController : ControllerBase
	{
		private readonly ApplicationDbContext context;

		public MessagesController(ApplicationDbContext context)
		{
			this.context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<Message>>> Get()
		{
			return await context.Messages.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult> Post(Message message)
		{
			//TODO: The stock command won’t be saved on the database as a post.
			{
				context.Add(message);

				await context.SaveChangesAsync();
				return Ok();
			}
		}
	}
}

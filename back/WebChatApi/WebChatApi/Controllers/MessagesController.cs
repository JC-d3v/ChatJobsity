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

		[HttpGet("{chatroomId}")]
		public async Task<ActionResult<List<MessageResponse>>> Get(int chatroomId)
		{
			return await context.Messages.Where(x=>x.ChatroomId==chatroomId)
                .Select(Message => new MessageResponse
                {
					MessageId=Message.MessageId,
					Text=Message.Text,
					Time=Message.Time,
					User=Message.User.Name,
					ChatRoom=Message.ChatRoom.Name
                }).ToListAsync();
        }

		[HttpPost]
		public async Task<ActionResult> Post(Message message)
		{
			message.UserId = 1;
			message.Time = DateTime.Now;
			if (!message.Text.StartsWith("/"))
			{
				context.Messages.Add(message);

				await context.SaveChangesAsync();
				return Ok();
			}
			else
			{
				return Ok();
				//TODO: Process Command.
			}
		}
	}
}

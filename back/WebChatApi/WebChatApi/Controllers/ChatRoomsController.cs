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
	[Route("api/chatrooms")]
	public class ChatRoomsController : ControllerBase
	{
		private readonly ApplicationDbContext context;

		public ChatRoomsController(ApplicationDbContext context)
		{
			this.context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<ChatRoom>>> Get()
		{
			return await context.ChatRooms.ToListAsync();
		}

		[HttpGet("{chatroomId}")]
        public async Task<ActionResult<ChatRoom>> Get(int chatroomId)
        {
            return await context.ChatRooms.FirstOrDefaultAsync(x => x.ChatRoomId == chatroomId);
        }

        [HttpPost]
		public async Task<ActionResult> Post(ChatRoom chatroom)
		{
			{
				context.Add(chatroom);
				await context.SaveChangesAsync();
				return Ok();
			}
		}
	}
}

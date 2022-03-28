using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebChatApi.Entities
{
	public class Message
	{
		[Key]
		public int MessageId { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }
		public int ChatroomId { get; set; }
		public ChatRoom ChatRoom { get; set; }
		public string Text { get; set; }
		public DateTime Time { get; set; }
	}
}

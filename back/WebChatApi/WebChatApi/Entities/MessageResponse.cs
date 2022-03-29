using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebChatApi.Entities
{
	public class MessageResponse
	{
		[Key]
		public int MessageId { get; set; }
		public string User { get; set; }
		public string ChatRoom { get; set; }
		public string Text { get; set; }
		public DateTime Time { get; set; }
	}
}

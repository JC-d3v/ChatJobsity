using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebChatApi.Entities
{
	public class ChatRoom
	{
		[Key]
		public int ChatId { get; set; }
		public string Name { get; set; }
	}
}

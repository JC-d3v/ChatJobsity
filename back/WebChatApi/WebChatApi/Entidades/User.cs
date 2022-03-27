using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebChatApi.Entities
{
	public class User
	{
		[Key]
		public int UId { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
	}
}

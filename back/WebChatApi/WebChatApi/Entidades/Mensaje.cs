using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebChatApi.Entidades
{
	public class Mensaje
	{
		[Key]
		public int MensajeId { get; set; }
		public int UId { get; set; }
		public Usuario Usuario { get; set; }
		public DateTime Time { get; set; }
		public string MensajeChat { get; set; }
	}
}

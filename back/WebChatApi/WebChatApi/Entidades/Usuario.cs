﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebChatApi.Entidades
{
	public class Usuario
	{
		[Key]
		public int UId { get; set; }
		public string Password { get; set; }
		public string Nombre { get; set; }
	}
}

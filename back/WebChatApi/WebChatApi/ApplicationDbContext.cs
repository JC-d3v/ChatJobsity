using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebChatApi.Entidades;

namespace WebChatApi
{
	public class ApplicationDbContext : DbContext
	{
		//public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}
		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Mensaje> Mensajes { get; set; }

	}
}

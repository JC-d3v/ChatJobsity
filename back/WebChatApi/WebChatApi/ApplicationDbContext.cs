using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebChatApi.Entities;

namespace WebChatApi
{
	public class ApplicationDbContext : DbContext
	{
		//public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}
		public DbSet<User> Users { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<ChatRoom> ChatRooms { get; set; }

	}
}

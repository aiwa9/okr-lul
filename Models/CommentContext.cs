using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cahaya.Models
{
	public class CommentContext : DbContext
	{
		private IConfigurationRoot _config;
		public CommentContext(IConfigurationRoot config, DbContextOptions options) : base()
		{
			_config = config;
		}

		public DbSet<Comments> Comments { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			optionsBuilder.UseSqlServer(_config["ConnectionStrings:WorldContextConnection"]);
		}
	}
}

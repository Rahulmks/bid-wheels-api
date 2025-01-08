using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bid_wheels.Services.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace bid_wheels.Services.Infrastructure
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions options)
				: base(options)
		{
		}
		public DbSet<Person> Person { get; set; }
	}
}

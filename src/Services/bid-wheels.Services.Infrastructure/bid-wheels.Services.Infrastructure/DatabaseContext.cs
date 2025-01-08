using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bid_wheels.Services.Domain.Model;
using bid_wheels.Services.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace bid_wheels.Services.Infrastructure
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions options)
				: base(options)
		{
		}
		public DbSet<Person> Persons { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Driver> Drivers { get; set; }
		public DbSet<Vehicle> Vehicles { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Bid> Bids { get; set; }
		public DbSet<OrderStatus> OrderStatuses { get; set; }
		public DbSet<OrderInvoice> OrderInvoices { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new PersonEntityConfiguration());
			modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new DriverEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new VehicleEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new BidEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new OrderStatusEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new OrderInvoiceEntityTypeConfiguration());
		}
	}
}

using bid_wheels.Services.Domain.Model;
using bid_wheels_api.src.Services.bid_wheels.Services.Infrastructure.bid_wheels.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bid_wheels.Services.Infrastructure.EntityConfigurations
{
	public class BidEntityTypeConfiguration : IEntityTypeConfiguration<Bid>
	{
		public void Configure(EntityTypeBuilder<Bid> builder)
		{
			builder.ToTable(DatabaseTableNameConstants.Bid, Constants.DEFAULT_SCHEMA);
			builder.HasKey(b => b.BidId);
			builder.Property(b => b.BidId).HasColumnName("bid_id");
			builder.Property(b => b.OrderId).HasColumnName("order_id");
			builder.Property(b => b.DriverId).HasColumnName("driver_id");
			builder.Property(b => b.Price).HasColumnName("price");
			builder.Property(b => b.ServiceDays).HasColumnName("days_required");
			builder.Property(b => b.CreatedDate).HasColumnName("created_date");
			builder.Property(b => b.LastModifiedDate).HasColumnName("last_modified_date");

			builder.HasOne(d => d.Orders)
			.WithMany(p => p.Bids)
			.HasForeignKey(d => d.OrderId)
			.HasConstraintName("fk_bid_order_id");

			builder.HasOne(d => d.Drivers)
			.WithMany(p => p.Bids)
			.HasForeignKey(d => d.DriverId)
			.HasConstraintName("fk_bid_driver_id");

		}

	}
}

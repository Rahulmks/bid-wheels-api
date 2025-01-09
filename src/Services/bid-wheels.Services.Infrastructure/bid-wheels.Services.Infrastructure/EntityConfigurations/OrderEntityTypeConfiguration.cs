using bid_wheels.Services.Domain.Model;
using bid_wheels_api.src.Services.bid_wheels.Services.Infrastructure.bid_wheels.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bid_wheels.Services.Infrastructure.EntityConfigurations
{
	public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable(DatabaseTableNameConstants.Order, Constants.DEFAULT_SCHEMA);
			builder.HasKey(b => b.OrderId);
			builder.Property(b => b.OrderId).HasColumnName("order_id");
			builder.Property(b => b.UserId).HasColumnName("user_id");
			builder.Property(b => b.Source).HasColumnName("source");
			builder.Property(b => b.Destination).HasColumnName("destination");
			builder.Property(b => b.ProductType).HasColumnName("product_type");
			builder.Property(b => b.SourceGPSCoordinates).HasColumnName("source_gps_coordinates");
			builder.Property(b => b.DestinationGPSCoordinates).HasColumnName("destination_gps_coordinates");
			builder.Property(b => b.VehicleType).HasColumnName("vehicle_type");
			builder.Property(b => b.PreferredTime).HasColumnName("preferred_time");
			builder.Property(b => b.Status).HasColumnName("status");
			builder.Property(b => b.CreatedDate).HasColumnName("created_date");
			builder.Property(b => b.LastModifiedDate).HasColumnName("last_modified_date");

			builder.HasOne(d => d.Users)
			.WithMany(p => p.Orders)
			.HasForeignKey(d => d.UserId)
			.HasConstraintName("fk_order_user_id");

		}

	}
}

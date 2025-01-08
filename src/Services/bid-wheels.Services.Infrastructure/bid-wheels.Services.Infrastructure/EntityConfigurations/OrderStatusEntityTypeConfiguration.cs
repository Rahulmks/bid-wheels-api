using bid_wheels.Services.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bid_wheels_api.src.Services.bid_wheels.Services.Infrastructure.bid_wheels.Services.Infrastructure.EntityConfigurations
{
	public class OrderStatusEntityTypeConfiguration : IEntityTypeConfiguration<OrderStatus>
	{
		public void Configure(EntityTypeBuilder<OrderStatus> builder)
		{
			builder.ToTable(DatabaseTableNameConstants.OrderStatus, Constants.DEFAULT_SCHEMA);
			builder.HasKey(b => b.OrderStatusId);
			builder.Property(b => b.OrderStatusId).HasColumnName("order_status_id");
			builder.Property(b => b.Status).HasColumnName("order_status");
		}

	}
}

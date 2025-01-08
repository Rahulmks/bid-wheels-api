using bid_wheels.Services.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bid_wheels_api.src.Services.bid_wheels.Services.Infrastructure.bid_wheels.Services.Infrastructure.EntityConfigurations
{
	public class OrderInvoiceEntityTypeConfiguration : IEntityTypeConfiguration<OrderInvoice>
	{
		public void Configure(EntityTypeBuilder<OrderInvoice> builder)
		{
			builder.ToTable(DatabaseTableNameConstants.OrderInvoice, Constants.DEFAULT_SCHEMA);
			builder.HasKey(b => b.OrderInvoiceId);
			builder.Property(b => b.OrderInvoiceId).HasColumnName("order_invoice_id");
			builder.Property(b => b.OrderId).HasColumnName("order_id");
			builder.Property(b => b.BidId).HasColumnName("bid_id");
			builder.Property(b => b.OrderStatusId).HasColumnName("order_status_id");
			builder.Property(b => b.PickUpDate).HasColumnName("pickup_date");
			builder.Property(b => b.InTransitDate).HasColumnName("in_transit_date");
			builder.Property(b => b.DeliveryDate).HasColumnName("delivery_date");

			builder.HasOne(d => d.Orders)
			.WithMany(p => p.OrderInvoices)
			.HasForeignKey(d => d.OrderId)
			.HasConstraintName("fk_order_invoice_order_id");

			builder.HasOne(d => d.Bids)
			.WithMany(p => p.OrderInvoices)
			.HasForeignKey(d => d.BidId)
			.HasConstraintName("fk_order_invoice_bid_id");

			builder.HasOne(d => d.Statuses)
			.WithMany(p => p.OrderInvoices)
			.HasForeignKey(d => d.OrderStatusId)
			.HasConstraintName("fk_order_invoice_order_status_id");

		}

	}
}

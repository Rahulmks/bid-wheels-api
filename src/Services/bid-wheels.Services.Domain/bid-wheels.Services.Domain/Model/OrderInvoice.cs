namespace bid_wheels.Services.Domain.Model
{
	public class OrderInvoice
	{
		public int OrderInvoiceId { get; set; }
		public int OrderId { get; set; }
		public string BidId { get; set; }
		public string OrderStatusId { get; set; }
		public DateTime? PickUpDate { get; set; }
		public DateTime? InTransitDate { get; set; }
		public DateTime? DeliveryDate { get; set; }
		public virtual Order Orders { get; set; } = null!;
		public virtual Bid Bids { get; set; } = null!;
		public virtual OrderStatus Statuses { get; set; } = null!;
	}
}

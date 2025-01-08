namespace bid_wheels.Services.Domain.Model
{
	public class Order
	{
		public int OrderId { get; set; }
		public int UserId { get; set; }
		public string Source { get; set; }
		public string Destination { get; set; }
		public string ProductType { get; set; }
		public string GPSCoordinates { get; set; }
		public string VehicleType { get; set; }
		public string PreferredTime { get; set; }
		public string Status { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? LastModifiedDate { get; set; }
		public virtual User Users { get; set; } = null!;
		public ICollection<Bid> Bids { get; set; } = new List<Bid>();
		public ICollection<OrderInvoice> OrderInvoices { get; set; } = new List<OrderInvoice>();
	}
}

namespace bid_wheels.Services.Domain.Model
{
	public class Bid
	{
		public int BidId { get; set; }
		public int OrderId { get; set; }
		public int DriverId { get; set; }
		public int Price { get; set; }
		public int ServiceDays { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? LastModifiedDate { get; set; }
		public virtual Order Orders { get; set; } = null!;
		public virtual Driver Drivers { get; set; } = null!;

		public ICollection<OrderInvoice> OrderInvoices { get; set; } = new List<OrderInvoice>();
	}
}

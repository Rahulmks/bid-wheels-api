namespace bid_wheels.Services.Domain.Model
{
	public class OrderStatus
	{
		public int OrderStatusId { get; set; }
		public string Status { get; set; }

		public ICollection<OrderInvoice> OrderInvoices { get; set; } = new List<OrderInvoice>();
	}
}

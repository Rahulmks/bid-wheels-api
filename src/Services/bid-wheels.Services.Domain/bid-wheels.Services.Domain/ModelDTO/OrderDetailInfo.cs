namespace bid_wheels.Services.Domain.Model
{
	public class OrderDetailInfo: Order
	{
		public int UserPersonId { get; set; }
		public int DriverPersonId { get; set; }
		public string UserName { get; set; }
		public int BidId { get; set; }
		public int DriverId { get; set; }
		public string DriverName { get; set; }
		public int Price { get; set; }
		public int ServiceDays { get; set; }
		public DateTime? BidCreatedDate { get; set; }
		public DateTime? BidLastModifiedDate { get; set; }
		public int OrderInvoiceId { get; set; }
		public int OrderStatusId { get; set; }
		public string DeliverStatus { get; set; }
		public DateTime? PickUpDate { get; set; }
		public DateTime? InTransitDate { get; set; }
		public DateTime? DeliveryDate { get; set; }
	}
}

namespace bid_wheels.Services.Domain.Model
{
	public class OrderBase
	{
		public int UserId { get; set; }
		public string Source { get; set; }
		public string Destination { get; set; }
		public string ProductType { get; set; }
		public string SourceGPSCoordinates { get; set; }
		public string DestinationGPSCoordinates { get; set; }
		public string VehicleType { get; set; }
		public int PreferredTime { get; set; }
	}

	public class OrderDTO : OrderBase
	{
		public int OrderId { get; set; }
		public string Status { get; set; }
		private DateTime _createdDate { get; set; }

		public DateTime CreatedDate
		{
			get => _createdDate;
			set => _createdDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
		}
	}

	public class Order: OrderDTO
	{
		private DateTime _LastModifiedDate { get; set; }

		public DateTime LastModifiedDate
		{
			get => _LastModifiedDate;
			set => _LastModifiedDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
		}

		public virtual User Users { get; set; } = null!;
		public ICollection<Bid> Bids { get; set; } = new List<Bid>();
		public ICollection<OrderInvoice> OrderInvoices { get; set; } = new List<OrderInvoice>();
	}
}

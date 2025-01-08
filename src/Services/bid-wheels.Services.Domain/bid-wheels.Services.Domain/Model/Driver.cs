namespace bid_wheels.Services.Domain.Model
{
	public class Driver
	{
		public int DriverId { get; set; }
		public int PersonId { get; set; }
		public int VehicleId { get; set; }
		public string LicenseNumber { get; set; }
		public string Location { get; set; }
		public string GPSCoordinates { get; set; }
		public bool IsFull { get; set; }

		public virtual Person Persons { get; set; } = null!;
		public virtual Vehicle Vehicles { get; set; } = null!;
		public ICollection<Bid> Bids { get; set; } = new List<Bid>();
	}
}

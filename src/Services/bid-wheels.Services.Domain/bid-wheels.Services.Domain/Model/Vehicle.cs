namespace bid_wheels.Services.Domain.Model
{
	public class Vehicle
	{
		public int VehicleId { get; set; }
		public string VehicleNumber { get; set; }
		public string VehicleType { get; set; }

		public ICollection<Driver> Drivers { get; set; } = new List<Driver>();
	}
}

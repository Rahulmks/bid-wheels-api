using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bid_wheels.Services.Domain.Model
{
	public class DriverOrderResponse
	{
		public int UserId { get; set; }
		public string Name { get; set; }
		public int OrderId { get; set; }
		public string Source { get; set; }
		public string Destination { get; set; }
		public string ProductType { get; set; }
		public string SourceGPSCoordinates { get; set; }
		public string DestinationGPSCoordinates { get; set; }
		public string VehicleType { get; set; }
		public int PreferredTime { get; set; }
		public int EstimatedCost { get; set; }

		public Boolean AlreadyBidded { get; set; }
		public DriverBid? Bid { get; set; }
	}

	public class DriverBid
	{
		public int BidId { get; set; }
		public int OrderId { get; set; }
		public int DriverId { get; set; }
		public int Price { get; set; }
		public int ServiceDays { get; set; }
	}
}

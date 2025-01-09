using System.Text.Json.Serialization;

namespace bid_wheels_api.Application.Model
{
	public class AddBidRequest
	{
		[JsonPropertyName("price")]
		public int Price { get; set; }

		[JsonPropertyName("daysRequired")]
		public int DaysRequired { get; set; }
	}
}

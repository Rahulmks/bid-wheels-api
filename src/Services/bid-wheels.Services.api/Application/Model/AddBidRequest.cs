using System.Text.Json.Serialization;

namespace bid_wheels_api.Application.Model
{
	public class AddBidRequest
	{
		[JsonPropertyName("price")]
		public string Price { get; set; }

		[JsonPropertyName("daysRequired")]
		public string DaysRequired { get; set; }
	}
}

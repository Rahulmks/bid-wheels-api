using System.Net;
using bid_wheels.Services.Domain;
using bid_wheels.Services.Domain.Model;
using bid_wheels.Services.Infrastructure;
using bid_wheels.Services.Infrastructure.Repository;
using bid_wheels_api.Application.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bid_wheels_api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	[EnableCors()]
	public class DriverController(IDriverRepository driverRepository) : ControllerBase
	{

		[HttpPost("AddBid/{orderId}/{driverId}")]
		public async Task<IActionResult> AddBidByOrderId([FromRoute]int orderId, [FromRoute]int driverId, [FromBody] AddBidRequest addBid)
		{
			var Bid = new Bid()
			{
				Price = addBid.Price,
				ServiceDays = addBid.DaysRequired,
				OrderId = orderId,
				DriverId = driverId,
				CreatedDate = DateAndTime.Now,
				LastModifiedDate = DateAndTime.Now
			};

			await driverRepository.AddBidAsync(Bid);

			return Ok(HttpStatusCode.Created);
		}
	}
}

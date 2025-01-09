using bid_wheels.Services.Domain;
using bid_wheels.Services.Domain.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bid_wheels_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[EnableCors()]
	public class UserController : ControllerBase
	{
		private readonly ILogger<UserController> _logger;
		private readonly IConfiguration _configuration;
		private readonly IUserRepository _userRepository;

		public UserController(ILogger<UserController> logger, 
			IConfiguration configuration, 
			IUserRepository userRepository
			)
		{
			_logger = logger;
			_configuration = configuration;
			_userRepository = userRepository;
		}

		[HttpGet("GetOrderDetails/{OrderId}")]
		public OrderDetailInfo GetOrderDetailByOrderId(int OrderId)
		{
			var user = _userRepository.GetOrderDetailsByOrderId(OrderId);
			return user;
		}

		[HttpGet("CreateOrg")]
		public IActionResult CreateOrg([FromBody] OrderBase resource)
		{
			var org = _userRepository.AddOrder(resource);
			return Ok(org);
		}

		[HttpGet("GetCurrentOrder/{OrderId}")]
		public OrderDTO GetCurrentOrder(int OrderId)
		{
			var order = _userRepository.GetCurrentOrderStatusByOrderId(OrderId);
			return order;
		}


	}
}

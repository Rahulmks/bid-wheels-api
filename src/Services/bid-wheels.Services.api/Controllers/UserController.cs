using System.Net;
using bid_wheels.Services.Domain;
using bid_wheels.Services.Domain.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bid_wheels_api.Controllers
{
	[Route("[controller]")]
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

		[HttpPost("CreateOrder")]
		public async Task<IActionResult> CreateOrg([FromBody] OrderBase resource)
		{
			await _userRepository.AddOrder(resource);
			return Ok(HttpStatusCode.Created);
		}

		[HttpGet("GetCurrentOrderStatus/{OrderId}")]
		public OrderDTO GetCurrentOrder(int OrderId)
		{
			var order = _userRepository.GetCurrentOrderStatusByOrderId(OrderId);
			return order;
		}

		[HttpGet("GetOrders/{userId}")]
		public List<OrderDTO> GetOrdersByDriverId(int userId)
		{
			var orders = _userRepository.GetAllOrdersByUserId(userId);
			return orders;
		}
	}
}

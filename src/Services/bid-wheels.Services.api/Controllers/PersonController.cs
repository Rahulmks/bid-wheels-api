using bid_wheels.Services.Domain;
using bid_wheels.Services.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bid_wheels_api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class PersonController : ControllerBase
	{
		private readonly ILogger<PersonController> _logger;
		private readonly IConfiguration _configuration;
		private readonly IPersonRepository _personRepository;

		public PersonController(ILogger<PersonController> logger,
			IConfiguration configuration,
			IPersonRepository personRepository
			)
		{
			_logger = logger;
			_configuration = configuration;
			_personRepository = personRepository;
		}

		[HttpGet("GetOrderHistory/{personId}")]
		public List<OrderDTO> GetAllOrders(int personId)
		{
			var orders = _personRepository.GetAllOrdersByPersonId(personId);
			return orders;
		}
	}
}

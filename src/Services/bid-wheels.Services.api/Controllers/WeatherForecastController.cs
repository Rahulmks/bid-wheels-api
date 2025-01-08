using bid_wheels.Services.Domain;
using bid_wheels.Services.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace bid_wheels_api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
				"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
			};

		private readonly ILogger<WeatherForecastController> _logger;
		private readonly IConfiguration _configuration;
		private readonly IPersonRepository _personRepository;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration, IPersonRepository personRepository)
		{
			_logger = logger;
			_configuration = configuration;
			_personRepository = personRepository;
		}

		[HttpGet("GetWeatherForecast")]
		public IEnumerable<WeatherForecast> Get()
		{
			var person = _personRepository.GetPerson();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
		}

		[HttpGet("GetPerson")]
		public Person GetPerson()
		{
			var person = _personRepository.GetPerson();
			return person;
		}

		[HttpGet("dbhealth", Name = "CheckDbHealth")]
		public IActionResult CheckDbHealth()
		{
			var connectionString = _configuration.GetConnectionString("PostgresConnection");
			try
			{
				using (var connection = new NpgsqlConnection(connectionString))
				{
					
					connection.Open();
					if (connection.State == ConnectionState.Open)
					{
						return Ok("Database connection is healthy.");
					}
					else
					{
						return StatusCode(500, "Database connection is not healthy.");
					}
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error checking database health.");
				return StatusCode(500, "Error checking database health.");
			}
		}
	}
}

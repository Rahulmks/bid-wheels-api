using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;

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

		public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
		}

		[HttpGet(Name = "GetWeatherForecast")]
		public IEnumerable<WeatherForecast> Get()
		{
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
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

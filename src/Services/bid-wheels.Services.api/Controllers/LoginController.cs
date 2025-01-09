using System.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace bid_wheels_api.Controllers
{
	[Route("")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly ILogger<LoginController> _logger;
		private readonly IConfiguration _configuration;

		public LoginController(ILogger<LoginController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
		}

		[EnableCors()]
		[HttpGet("login", Name = "LoginAuthentication")]
		public IActionResult Login([FromQuery] string userName, [FromQuery] string password)
		{
			var connectionString = _configuration.GetConnectionString("PostgresConnection");
			try
			{
				using (var connection = new NpgsqlConnection(connectionString))
				{
					connection.Open();
					if (connection.State == ConnectionState.Open)
					{
						using (var cmd = new NpgsqlCommand("select * from bw.person where name ILIKE @user and password = @password", connection))
						{
							cmd.Parameters.AddWithValue("user", userName);
							cmd.Parameters.AddWithValue("password", password);
							cmd.CommandTimeout = 30;
							using (var reader = cmd.ExecuteReader())
							{
								if (reader.Read())
								{
									var user = new
									{
										Id = reader["person_id"],
										Username = reader["name"],
										Email = reader["mail_id"],
										Phone = reader["phone_number"],
										Password = reader["password"],
										Feedback = reader["aggregate_feedback"],
										Usertype = reader["user_type"]
									};

									return Ok(user);
								}
								else
								{
									_logger.LogInformation("Invalid username or password.");
									return StatusCode(401, "Invalid username or password.");
								}

							}
						}
					}
					else
					{
						return StatusCode(500, "Database connection is not healthy.");
					}
				}

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error during login operation.");
				return StatusCode(500, "Error during login operation.");
			}
		}
	}
}

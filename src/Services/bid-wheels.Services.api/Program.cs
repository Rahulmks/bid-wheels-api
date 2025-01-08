using bid_wheels.Services.Infrastructure;
using bid_wheels_api.Configuration;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigureServices(builder.Configuration, builder.Services);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
{
	services
		 .AddCors(options =>
		 {
			 options.AddDefaultPolicy(policy =>
			 {
				 policy
				   .AllowAnyOrigin()
				   .WithMethods("DELETE", "GET", "POST", "PATCH");
			 });
		 });

	services.AddMvc();
	services.AddDependencyInjectionConfiguration(configuration);

	var connectionString = configuration["ConnectionStrings:PostgresConnection"];
	var dbPassword = configuration["ConnectionStrings:DbPassword"];
	var builder = new NpgsqlConnectionStringBuilder(connectionString)
	{
		Password = dbPassword
	};
	services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(builder.ConnectionString));
}

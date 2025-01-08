using bid_wheels.Services.Domain;
using bid_wheels.Services.Infrastructure.Repository;

namespace bid_wheels_api.Configuration
{
	public static class DependencyInjectionConfiguration
	{
		public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddHttpContextAccessor();

			services.AddScoped<IPersonRepository, PersonRepository>();

			return services;
		}
	}
}

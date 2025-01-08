using bid_wheels.Services.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bid_wheels_api.src.Services.bid_wheels.Services.Infrastructure.bid_wheels.Services.Infrastructure.EntityConfigurations
{
	public class VehicleEntityTypeConfiguration : IEntityTypeConfiguration<Vehicle>
	{
		public void Configure(EntityTypeBuilder<Vehicle> builder)
		{
			builder.ToTable(DatabaseTableNameConstants.Vehicle, Constants.DEFAULT_SCHEMA);
			builder.HasKey(b => b.VehicleId);
			builder.Property(b => b.VehicleId).HasColumnName("vehicle_id");
			builder.Property(b => b.VehicleNumber).HasColumnName("vehicle_number");
			builder.Property(b => b.VehicleType).HasColumnName("vehicle_type");
		}

	}
}

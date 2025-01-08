using bid_wheels.Services.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bid_wheels_api.src.Services.bid_wheels.Services.Infrastructure.bid_wheels.Services.Infrastructure.EntityConfigurations
{
	public class DriverEntityTypeConfiguration : IEntityTypeConfiguration<Driver>
	{
		public void Configure(EntityTypeBuilder<Driver> builder)
		{
			builder.ToTable(DatabaseTableNameConstants.Driver, Constants.DEFAULT_SCHEMA);
			builder.HasKey(b => b.DriverId);
			builder.Property(b => b.DriverId).HasColumnName("driver_id");
			builder.Property(b => b.PersonId).HasColumnName("person_id");
			builder.Property(b => b.VehicleId).HasColumnName("vehicle_id");
			builder.Property(b => b.LicenseNumber).HasColumnName("license_number");
			builder.Property(b => b.Location).HasColumnName("location");
			builder.Property(b => b.GPSCoordinates).HasColumnName("gps_coordinates");
			builder.Property(b => b.IsFull).HasColumnName("is_full");

			builder.HasOne(d => d.Persons)
			.WithMany(p => p.Drivers)
			.HasForeignKey(d => d.PersonId)
			.HasConstraintName("fk_driver_person_id");

			builder.HasOne(d => d.Vehicles)
			.WithMany(p => p.Drivers)
			.HasForeignKey(d => d.VehicleId)
			.HasConstraintName("fk_driver_vehicle_id");
		}

	}
}

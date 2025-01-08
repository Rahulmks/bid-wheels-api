using bid_wheels.Services.Domain.Model;
using bid_wheels_api.src.Services.bid_wheels.Services.Infrastructure.bid_wheels.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bid_wheels.Services.Infrastructure.EntityConfigurations
{
	public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable(DatabaseTableNameConstants.User, Constants.DEFAULT_SCHEMA);
			builder.HasKey(b => b.UserId);
			builder.Property(b => b.PersonId).HasColumnName("person_id");
			builder.Property(b => b.UserId).HasColumnName("user_id");

		}

	}
}

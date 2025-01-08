using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using bid_wheels.Services.Domain.Model;

namespace bid_wheels.Services.Infrastructure.EntityConfigurations
{
	public class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
	{
		public void Configure(EntityTypeBuilder<Person> builder)
		{
			builder.ToTable("person", "dbo");

			builder.Property(entity => entity.PersonId)
				   .HasColumnName("person_id");
			
			builder.Property(entity => entity.Name)
				   .HasColumnName("name");

			builder.Property(entity => entity.Email)
				   .HasColumnName("mail_id");

			builder.Property(entity => entity.PhoneNumber)
				   .HasColumnName("phone_number");

			builder.Property(entity => entity.Password)
				   .HasColumnName("password");

			builder.Property(entity => entity.feedback)
				   .HasColumnName("feedback");

			builder.HasKey(entity => entity.PersonId);

		}
	}
}

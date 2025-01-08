using bid_wheels.Services.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bid_wheels_api.src.Services.bid_wheels.Services.Infrastructure.bid_wheels.Services.Infrastructure.EntityConfigurations
{
	public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
	{
		public void Configure(EntityTypeBuilder<Person> builder)
		{
			builder.ToTable(DatabaseTableNameConstants.Person, Constants.DEFAULT_SCHEMA);
			builder.HasKey(b => b.PersonId);
			builder.Property(b => b.PersonId).HasColumnName("person_id");
			builder.Property(b => b.Name).HasColumnName("name");
			builder.Property(b => b.MailId).HasColumnName("mail_id");
			builder.Property(b => b.PhoneNumber).HasColumnName("phone_number");
			builder.Property(b => b.Password).HasColumnName("password");
			builder.Property(b => b.Feedback).HasColumnName("aggregate_feedback");
			builder.Property(b => b.CreatedDate).HasColumnName("created_date");
			builder.Property(b => b.LastModifiedDate).HasColumnName("last_modified_date");
			builder.Property(b => b.UserType).HasColumnName("user_type");
		}

	}
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using bid_wheels.Services.Domain.Model;
using bid_wheels_api.src.Services.bid_wheels.Services.Infrastructure.bid_wheels.Services.Infrastructure;

namespace bid_wheels.Services.Infrastructure.EntityConfigurations
{
	public class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
	{
		public void Configure(EntityTypeBuilder<Person> builder)
		{
			builder.ToTable(DatabaseTableNameConstants.Person, Constants.DEFAULT_SCHEMA);

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

			builder.Property(b => b.CreatedDate).
				HasColumnName("created_date");

			builder.Property(b => b.LastModifiedDate).
				HasColumnName("last_modified_date");

			builder.Property(b => b.UserType).
				HasColumnName("user_type");
			
			builder.Property(b => b.No_of_Reviews).
				HasColumnName("No_of_Reviews");

			builder.Property(b => b.AggreagateFeedback).
				HasColumnName("aggregate_feedback");

			builder.HasKey(entity => entity.PersonId);

		}
	}
}

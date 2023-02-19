using FilmsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsApp.Data.EntitiesConfiguration
{
	internal class PersonConfiguration : IEntityTypeConfiguration<Person>
	{
		public void Configure(EntityTypeBuilder<Person> builder)
		{
			builder
				.ToTable("person");

			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder
				.Property(x => x.Name)
				.HasColumnName("name");

			builder
				.Property(x => x.Growth)
				.HasColumnName("growth");

			builder
				.Property(x => x.DateBirth)
				.HasColumnName("birthday");

			builder
				.Property(x => x.DateDeath)
				.HasColumnName("death");

			builder
				.Property(x => x.BirthPlace)
				.HasColumnName("birthPlace");

			builder
				.Property(x => x.GenderId)
				.HasColumnName("gender_id");

			builder
				.HasOne(x => x.Gender)
				.WithMany(x => x.People)
				.HasForeignKey(x => x.GenderId);
		}
	}
}

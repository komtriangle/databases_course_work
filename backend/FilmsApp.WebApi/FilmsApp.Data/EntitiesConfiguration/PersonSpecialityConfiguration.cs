using FilmsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsApp.Data.EntitiesConfiguration
{
	internal class PersonSpecialityConfiguration : IEntityTypeConfiguration<PersonSpeciality>
	{
		public void Configure(EntityTypeBuilder<PersonSpeciality> builder)
		{
			builder
				.ToTable("person_speciality");

			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder
				.Property(x => x.PersonId)
				.HasColumnName("person_id");

			builder
				.Property(x => x.SpecialityId)
				.HasColumnName("speciality_id");

			builder
				.HasOne(x => x.Person)
				.WithMany(x => x.Specialities)
				.HasForeignKey(x => x.PersonId);

			builder
				.HasOne(x => x.Speciality)
				.WithMany(x => x.People)
				.HasForeignKey(x => x.SpecialityId);

		}
	}
}

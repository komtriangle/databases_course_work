using FilmsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsApp.Data.EntitiesConfiguration
{
	internal class FilmPersonConfiguration : IEntityTypeConfiguration<FilmPerson>
	{
		public void Configure(EntityTypeBuilder<FilmPerson> builder)
		{
			builder
				.ToTable("film_person");

			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.HasColumnName("id")
				.HasColumnType("int")
				.ValueGeneratedOnAdd();

			builder
				.Property(x => x.FilmId)
				.HasColumnName("film_id");

			builder
				.Property(x => x.SpecialityId)
				.HasColumnName("speciality_id");

			builder
				.Property(x => x.PersonId)
				.HasColumnName("person_id");

			builder
				.HasOne(x => x.Film)
				.WithMany(x => x.People)
				.HasForeignKey(x => x.PersonId);

			builder
				.HasOne(x => x.Person)
				.WithMany(x => x.Films)
				.HasForeignKey(x => x.PersonId);

			builder
				.HasOne(x => x.Speciality)
				.WithMany(x => x.FilmPeople)
				.HasForeignKey(x => x.SpecialityId);
		}
	}
}

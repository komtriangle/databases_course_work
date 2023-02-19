using FilmsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsApp.Data.EntitiesConfiguration
{
	internal class FilmConfiguration : IEntityTypeConfiguration<Film>
	{
		public void Configure(EntityTypeBuilder<Film> builder)
		{
			builder
				.ToTable("film");

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
				.Property(x => x.EngName)
				.HasColumnName("alternative_name");

			builder
				.Property(x => x.Description)
				.HasColumnName("description");

			builder
				.Property(x => x.YearOfRelease)
				.HasJsonPropertyName("year_of_release");

			builder
				.Property(x => x.Rating)
				.HasColumnName("rating");

			builder
				.Property(x => x.Length)
				.HasColumnName("length");

			builder
				.Property(x => x.FilmType)
				.HasColumnName("film_type_id");

			builder
				.HasOne(x => x.FilmType)
				.WithMany(x => x.Films)
				.HasForeignKey(x => x.FilmTypeId);
		}
	}
}

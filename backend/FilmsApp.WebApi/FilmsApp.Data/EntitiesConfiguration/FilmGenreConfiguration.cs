using FilmsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsApp.Data.EntitiesConfiguration
{
	internal class FilmGenreConfiguration : IEntityTypeConfiguration<FilmGenre>
	{
		public void Configure(EntityTypeBuilder<FilmGenre> builder)
		{
			builder
				.ToTable("film_genre");

			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder
				.Property(x => x.GenreId)
				.HasColumnName("genre_id");

			builder
				.Property(x => x.FilmId)
				.HasColumnName("film_id");

			builder
				.HasOne(x => x.Film)
				.WithMany(x => x.Genres)
				.HasForeignKey(x => x.FilmId);

			builder
				.HasOne(x => x.Genre)
				.WithMany(x => x.Films)
				.HasForeignKey(x => x.GenreId);
		}
	}
}

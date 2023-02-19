using FilmsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsApp.Data.EntitiesConfiguration
{
	internal class FilmCountryConfiguration : IEntityTypeConfiguration<FilmCountry>
	{
		public void Configure(EntityTypeBuilder<FilmCountry> builder)
		{
			builder
				.ToTable("film_country");

			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder
				.Property(x => x.CountryId)
				.HasColumnName("country_id");

			builder
				.Property(x => x.FilmId)
				.HasColumnName("film_id");

			builder
				.HasOne(x => x.Country)
				.WithMany(x => x.Countries)
				.HasForeignKey(x => x.CountryId);

			builder
				.HasOne(x => x.Film)
				.WithMany(x => x.Countries)
				.HasForeignKey(x => x.FilmId);
		}
	}
}

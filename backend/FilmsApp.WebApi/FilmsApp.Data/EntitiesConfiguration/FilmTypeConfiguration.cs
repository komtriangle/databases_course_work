using FilmsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsApp.Data.EntitiesConfiguration
{
	internal class FilmTypeConfiguration : IEntityTypeConfiguration<FilmType>
	{
		public void Configure(EntityTypeBuilder<FilmType> builder)
		{
			builder
				.ToTable("film_type");

			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.HasColumnName("id")
				.HasColumnType("int")
				.ValueGeneratedOnAdd();

			builder
				.Property(x => x.Name)
				.HasColumnName("name")
				.IsRequired();
		}
	}
}

using FilmsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsApp.Data.EntitiesConfiguration
{
	internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
	{
		public void Configure(EntityTypeBuilder<Genre> builder)
		{
			builder
				.ToTable("genre");

			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder
				.Property(x => x.Name)
				.HasColumnName("name");
		}
	}
}

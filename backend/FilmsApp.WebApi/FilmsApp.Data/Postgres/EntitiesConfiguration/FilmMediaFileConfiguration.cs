using FilmsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsApp.Data.EntitiesConfiguration
{
	internal class FilmMediaFileConfiguration : IEntityTypeConfiguration<FilmMediaFile>
	{
		public void Configure(EntityTypeBuilder<FilmMediaFile> builder)
		{

			builder
				.ToTable("film_media_file");

			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder
				.Property(x => x.MediaFileId)
				.HasColumnName("film_id");

			builder
				.Property(x => x.FileId)
				.HasColumnName("file_id");

			builder
				.HasOne(x => x.Film)
				.WithMany(x => x.MediaFiles)
				.HasForeignKey(x => x.MediaFileId);

			builder
				.HasOne(x => x.MediaFile)
				.WithMany(x => x.Films)
				.HasForeignKey(x => x.FileId);
			;
		}
	}
}

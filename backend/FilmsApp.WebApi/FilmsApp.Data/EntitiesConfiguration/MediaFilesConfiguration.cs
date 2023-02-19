using FilmsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsApp.Data.EntitiesConfiguration
{
	internal class MediaFilesConfiguration : IEntityTypeConfiguration<MediaFile>
	{
		public void Configure(EntityTypeBuilder<MediaFile> builder)
		{
			builder
				.ToTable("media_files");

			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder
				.Property(x => x.Path)
				.HasColumnName("path");

			builder
				.HasOne(x => x.MediaFileExtension)
				.WithMany(x => x.MediaFiles)
				.HasForeignKey(x => x.MediaFileExtensionId);

		}
	}
}

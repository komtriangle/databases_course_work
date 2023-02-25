using FilmsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsApp.Data.EntitiesConfiguration
{
	internal class MediaFileExtensionConfiguration : IEntityTypeConfiguration<MediaFileExtension>
	{
		public void Configure(EntityTypeBuilder<MediaFileExtension> builder)
		{
			builder
				.ToTable("media_file_extension");

			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder
				.Property(x => x.Extension)
				.HasColumnName("extension");

			builder
				.Property(x => x.MediaFileTypeId)
				.HasColumnName("media_file_type_id");

			builder.HasOne(x => x.MediaFileType)
				.WithMany(x => x.MediaFileExtensions)
				.HasForeignKey(x => x.MediaFileTypeId);
		}
	}
}

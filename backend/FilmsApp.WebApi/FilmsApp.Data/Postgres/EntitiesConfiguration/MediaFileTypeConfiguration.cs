using FilmsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsApp.Data.EntitiesConfiguration
{
	internal class MediaFileTypeConfiguration : IEntityTypeConfiguration<MediaFileType>
	{
		public void Configure(EntityTypeBuilder<MediaFileType> builder)
		{
			builder
				.ToTable("media_file_type");

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

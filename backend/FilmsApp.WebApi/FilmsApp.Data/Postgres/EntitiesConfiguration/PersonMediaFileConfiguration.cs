using FilmsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsApp.Data.EntitiesConfiguration
{
	internal class PersonMediaFileConfiguration : IEntityTypeConfiguration<PersonMediaFile>
	{
		public void Configure(EntityTypeBuilder<PersonMediaFile> builder)
		{
			builder
				.ToTable("person_media_file");

			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder
				.Property(x => x.PersonId)
				.HasColumnName("person_id");

			builder
				.Property(x => x.MediaaFileId)
				.HasColumnName("media_file_id");

			builder
				.HasOne(x => x.MediaFile)
				.WithMany(x => x.People)
				.HasForeignKey(x => x.MediaaFileId);

			builder
				.HasOne(x => x.Person)
				.WithMany(x => x.MediaFiles)
				.HasForeignKey(x => x.PersonId);
		}
	}
}

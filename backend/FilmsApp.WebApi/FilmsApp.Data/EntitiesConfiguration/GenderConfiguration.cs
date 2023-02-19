using FilmsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsApp.Data.EntitiesConfiguration
{
	internal class GenderConfiguration : IEntityTypeConfiguration<Gender>
	{
		public void Configure(EntityTypeBuilder<Gender> builder)
		{
			builder
				.ToTable("gender");

			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder
				.Property(x => x.Value)
				.HasColumnName("value")
				.ValueGeneratedOnAdd();
		}
	}
}

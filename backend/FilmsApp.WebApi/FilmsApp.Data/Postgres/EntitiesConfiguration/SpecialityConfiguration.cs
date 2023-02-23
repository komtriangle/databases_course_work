using FilmsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsApp.Data.EntitiesConfiguration
{
	internal class SpecialityConfiguration : IEntityTypeConfiguration<Speciality>
	{
		public void Configure(EntityTypeBuilder<Speciality> builder)
		{
			builder
				.ToTable("speciality");

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

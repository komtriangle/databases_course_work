using FilmsApp.Data.Postgres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsApp.Data.Postgres.EntitiesConfiguration
{
	internal class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder
				.ToTable("users");

			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.HasColumnName("id")
				.HasColumnType("int");

			builder
				.Property(x => x.Email)
				.HasColumnName("email")
				.HasColumnType("text");
		}
	}
}

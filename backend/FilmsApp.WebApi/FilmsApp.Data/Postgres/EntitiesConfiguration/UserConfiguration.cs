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
				.ToTable("app_user");

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

			builder
				.HasMany(x => x.Roles)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId);
		}
	}
}

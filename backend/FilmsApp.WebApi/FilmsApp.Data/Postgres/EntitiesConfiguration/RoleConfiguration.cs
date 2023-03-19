using FilmsApp.Data.Postgres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsApp.Data.Postgres.EntitiesConfiguration
{
	internal class RoleConfiguration : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder
				.ToTable("role");

			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.HasColumnName("id")
				.HasColumnType("int");

			builder
				.Property(x => x.Name)
				.HasColumnName("name")
				.HasColumnType("text");

			builder.HasMany(x => x.Users)
				.WithOne(x => x.Role)
				.HasForeignKey(x => x.RoleId);
		}
	}
}

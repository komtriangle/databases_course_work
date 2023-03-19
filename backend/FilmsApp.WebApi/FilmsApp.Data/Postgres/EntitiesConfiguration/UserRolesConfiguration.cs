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
	internal class UserRolesConfiguration : IEntityTypeConfiguration<UserRoles>
	{
		public void Configure(EntityTypeBuilder<UserRoles> builder)
		{
			builder
				.ToTable("user_role");

			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.HasColumnName("id")
				.HasColumnType("int");

			builder
				.Property(x => x.UserId)
				.HasColumnName("user_id")
				.HasColumnType("int");

			builder
				.Property(x => x.RoleId)
				.HasColumnName("role_id")
				.HasColumnType("int");
		}
	}
}

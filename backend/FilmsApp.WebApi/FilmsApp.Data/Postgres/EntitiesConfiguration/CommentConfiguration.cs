using FilmsApp.Data.Postgres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsApp.Data.Postgres.EntitiesConfiguration
{
	internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
	{
		public void Configure(EntityTypeBuilder<Comment> builder)
		{
			builder
				.ToTable("comments");

			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Id)
				.HasColumnName("id")
				.HasColumnType("int")
				.ValueGeneratedOnAdd();

			builder
				.Property(x => x.Text)
				.HasColumnName("text")
				.HasColumnType("text")
				.IsRequired();

			builder
				.Property(x => x.Stars)
				.HasColumnName("stars")
				.HasColumnType("smallint")
				.IsRequired();

			builder
				.Property(x => x.UserId)
				.HasColumnName("user_id")
				.IsRequired();

			builder
				.Property(x => x.FilmId)
				.HasColumnName("film_id")
				.IsRequired();

			builder
				.HasOne(x => x.User)
				.WithMany(x => x.Comments)
				.HasForeignKey(x => x.UserId)
				.IsRequired();

			builder
				.HasOne(x => x.Film)
				.WithMany(x => x.Comments)
				.HasForeignKey(x => x.FilmId)
				.IsRequired();
		}
	}
}

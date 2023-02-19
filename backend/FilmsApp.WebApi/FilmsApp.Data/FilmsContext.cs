using FilmsApp.Data.Entities;
using FilmsApp.Data.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsApp.Data
{
	public class FilmsContext : DbContext
	{
		public FilmsContext(DbContextOptions<FilmsContext> options)
		   : base(options)
		{

		}

		public DbSet<Country> Countries { get; set; }
		public DbSet<Gender> Genders { get; set; }
		public DbSet<Film> Films { get; set; }
		public DbSet<FilmCountry> FilmCountries { get; set; }
		public DbSet<MediaFileExtension> MediaFileExtensions { get; set; }
		public DbSet<MediaFile> MediaFiles { get; set; }
		public DbSet<FilmMediaFile> FilmMediaFiles { get; set; }
		public DbSet<Speciality> Specialities { get; set; }
		public DbSet<Person> People { get; set; }
		public DbSet<PersonSpeciality> PersonSpecialities { get; set; }
		public DbSet<PersonMediaFile> PersonMediaFiles { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<FilmGenre> FilmGenres { get; set; }
		public DbSet<FilmType> FilmType { get; set; }
		public DbSet<FilmPerson> FilmPeople { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfiguration(new CountryConfiguration());
			builder.ApplyConfiguration(new GenderConfiguration());
			builder.ApplyConfiguration(new FilmConfiguration());
			builder.ApplyConfiguration(new FilmCountryConfiguration());
			builder.ApplyConfiguration(new MediaFileTypeConfiguration());
			builder.ApplyConfiguration(new MediaFileExtensionConfiguration());
			builder.ApplyConfiguration(new MediaFilesConfiguration());
			builder.ApplyConfiguration(new FilmMediaFileConfiguration());
			builder.ApplyConfiguration(new SpecialityConfiguration());
			builder.ApplyConfiguration(new PersonConfiguration());
			builder.ApplyConfiguration(new PersonSpecialityConfiguration());
			builder.ApplyConfiguration(new PersonMediaFileConfiguration());
			builder.ApplyConfiguration(new GenreConfiguration());
			builder.ApplyConfiguration(new FilmGenreConfiguration());
			builder.ApplyConfiguration(new FilmTypeConfiguration());
			builder.ApplyConfiguration(new FilmPersonConfiguration());
		}
	}
}


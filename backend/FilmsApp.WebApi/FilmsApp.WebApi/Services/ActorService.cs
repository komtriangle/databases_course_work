using FilmsApp.Data;
using FilmsApp.Data.Entities;
using FilmsApp.Data.Enums;
using FilmsApp.WebApi.DTO;
using FilmsApp.WebApi.DTO.Extensions;
using FilmsApp.WebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmsApp.WebApi.Services
{
	public class ActorService : IActorService
	{
		private readonly IDbContextFactory<FilmsContext> _dbContextFactory;

		public ActorService(IDbContextFactory<FilmsContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}
		public async Task<IEnumerable<PersonDTO>> GetActorsAsync(string searchQuery, int count, int offset)
		{


			using(FilmsContext context = _dbContextFactory.CreateDbContext())
			{
				IQueryable<Person> allActors = context.People
					.Where(x => x.Specialities.Any(x => x.SpecialityId == (int)Specialities.Actor));

				var actors = await SearchActors(searchQuery, allActors, count, offset);

				return actors
					.Skip(offset)
					.Take(count)
					.Select(actor => actor.ToDTO())
					.OrderByDescending(actor => actor.Films.Count())
					.ToList();
			}
		}


		private async Task<List<Person>> SearchActors(string searchQuery, IQueryable<Person> allActors, int count, int offset)
		{
			searchQuery = searchQuery ?? string.Empty;

			string[] words = searchQuery.Split(' ').Take(2).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

			List<Person> actors = allActors.Where(x => x.Name == searchQuery).ToList();
			IQueryable<Person> actorsToAdd = null;

			if(words.Length == 1)
			{
				actorsToAdd = allActors.Where(x => x.Name.Contains(words[0]));
			}
			else if(words.Length == 2)
			{
				actorsToAdd = allActors.Where(x => x.Name.Contains(words[0]) ||
					x.Name.Contains(words[1]));
			}

			if(actorsToAdd != null)
			{
				actorsToAdd
					.Include(x => x.Films)
						.ThenInclude(x => x.Film)
					.Include(x => x.MediaFiles)
						.ThenInclude(x => x.MediaFile)
					.Include(x => x.Specialities)
						.ThenInclude(x => x.Speciality)
					.ToList()
					.Where(x => !actors.Any(a => a.Id == x.Id))
					.ToList();

				actors.AddRange(actorsToAdd);
			}

			if(actors.Count < count + offset && string.IsNullOrEmpty(searchQuery))
			{
				actors.AddRange(allActors.Take(count + offset - actors.Count)
					.Include(x => x.Films)
						.ThenInclude(x => x.Film)
					.Include(x => x.MediaFiles)
						.ThenInclude(x => x.MediaFile)
					.Include(x => x.Specialities)
						.ThenInclude(x => x.Speciality)
					.ToList()
					.Where(x => !actors.Any(a => a.Id == x.Id))
					.ToList());
			}

			
			return actors
				.Distinct()
				.ToList();
		}
	}
}

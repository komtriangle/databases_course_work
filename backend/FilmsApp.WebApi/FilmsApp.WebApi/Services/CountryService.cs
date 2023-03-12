using FilmsApp.Data;
using FilmsApp.Data.Entities;
using FilmsApp.WebApi.DTO;
using FilmsApp.WebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmsApp.WebApi.Services
{
	public class CountryService : ICountryService
	{
		private readonly IDbContextFactory<FilmsContext> _dbContextFactory;

		public CountryService(IDbContextFactory<FilmsContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}
		public async Task<IEnumerable<CountryDTO>> GetCountriesAsync(string searchQuery, int count, int offset)
		{
			try
			{
				using(FilmsContext context = await _dbContextFactory.CreateDbContextAsync())
				{
					IQueryable<Country> countries = context.Countries;

					if(!string.IsNullOrWhiteSpace(searchQuery))
					{
						countries = context.Countries.Where(x => x.Name.ToLower()
						.StartsWith(searchQuery.ToLower()));
					}

					return await countries.Skip(offset)
							.Take(count)
							.Select(x => new CountryDTO
							{
								Id = x.Id,
								Name = x.Name
							})
							.ToArrayAsync();
				}
			}
			catch(Exception ex)
			{
				throw;
			}
		}
	}
}

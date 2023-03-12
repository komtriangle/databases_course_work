using FilmsApp.Data;
using FilmsApp.WebApi.DTO;
using FilmsApp.WebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmsApp.WebApi.Services
{
	public class FilmTypeService : IFilmTypeService
	{
		private readonly IDbContextFactory<FilmsContext> _dbContextFactory;

		public FilmTypeService(IDbContextFactory<FilmsContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		public async Task<IEnumerable<FilmTypeDTO>> GetFilmTypesAsync()
		{
			try
			{
				using(FilmsContext context = await _dbContextFactory.CreateDbContextAsync())
				{
					return await context.FilmType
						.Select(x => new FilmTypeDTO
						{
							Id = x.Id,
							Name = x.Name
						})
						.ToArrayAsync();
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}

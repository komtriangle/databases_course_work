using FilmsApp.Data;
using FilmsApp.WebApi.DTO;
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
		public Task<IEnumerable<PersonDTO>> GetActors(string searchQuary, int count, int offset)
		{
			throw new NotImplementedException();
		}
	}
}

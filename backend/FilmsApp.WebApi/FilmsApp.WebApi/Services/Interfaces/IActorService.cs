using FilmsApp.WebApi.DTO;

namespace FilmsApp.WebApi.Services.Interfaces
{
	public interface IActorService
	{
		Task<IEnumerable<PersonDTO>> GetActors(string searchQuary, int count, int offset);
	}
}

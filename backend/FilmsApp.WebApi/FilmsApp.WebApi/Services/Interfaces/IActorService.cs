using FilmsApp.WebApi.DTO;

namespace FilmsApp.WebApi.Services.Interfaces
{
	public interface IActorService
	{
		Task<IEnumerable<PersonDTO>> GetActorsAsync(string searchQuary, int count, int offset);
	}
}

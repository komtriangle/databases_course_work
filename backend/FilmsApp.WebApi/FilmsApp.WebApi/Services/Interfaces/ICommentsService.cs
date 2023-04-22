using FilmsApp.WebApi.DTO;

namespace FilmsApp.WebApi.Services.Interfaces
{
	public interface ICommentsService
	{
		Task<int> CreateAsync(CommentDTO comment);

		Task DeleteAsync(int id);
	}
}

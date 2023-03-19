using FilmsApp.Data.Postgres.Entities;

namespace FilmsApp.WebApi.Services.Interfaces
{
	public interface IUserService
	{
		Task<User> GetUserAsync(string email);

		Task CreateUserAsync(string email);

		Task<IEnumerable<Role>> GetUserRolesAsync(int id);

		Task AddRoleToUserAsync(int userId, int roleId);
	}
}

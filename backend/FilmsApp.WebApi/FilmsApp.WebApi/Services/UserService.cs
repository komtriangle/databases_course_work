using FilmsApp.Data;
using FilmsApp.Data.Postgres.Entities;
using FilmsApp.WebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmsApp.WebApi.Services
{
	public class UserService : IUserService
	{
		private readonly IDbContextFactory<FilmsContext> _dbContextFactory;

		public UserService(IDbContextFactory<FilmsContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		public async Task CreateUserAsync(string email)
		{
			try
			{
				using(FilmsContext context = _dbContextFactory.CreateDbContext())
				{
					var user = new User { Email = email };

					await context.Users.AddAsync(user);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public async Task<User> GetUserAsync(string email)
		{
			try
			{
				using(FilmsContext context = _dbContextFactory.CreateDbContext())
				{
					return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
				}
			}
			catch(Exception ex)
			{
				throw;
			}
		}

		public async Task<IEnumerable<Role>> GetUserRolesAsync(int id)
		{
			try
			{
				using(FilmsContext context = _dbContextFactory.CreateDbContext())
				{
					User user = await context.Users.FindAsync(id);

					if(user == null)
					{
						return null;
					}

					return user.Roles.Select(x => x.Role).ToList();
				}
			}
			catch(Exception ex)
			{
				throw;
			}
		}

		public async Task AddRoleToUserAsync(int userId, int roleId)
		{
			try
			{
				using(FilmsContext context = _dbContextFactory.CreateDbContext())
				{
					UserRoles userRole = await context.UserRoles.FirstOrDefaultAsync(x => x.UserId == userId && x.RoleId == roleId);

					if(userRole == null)
					{
						userRole = new UserRoles
						{
							UserId = userId,
							RoleId = roleId
						};

						await context.UserRoles.AddAsync(userRole);
						await context.SaveChangesAsync();
					}

				}
			}
			catch(Exception ex)
			{
				throw;
			}
		}
	}
}

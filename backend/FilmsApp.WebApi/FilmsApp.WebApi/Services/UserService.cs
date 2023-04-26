using FilmsApp.Data;
using FilmsApp.Data.Postgres.Entities;
using FilmsApp.WebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmsApp.WebApi.Services
{
	public class UserService : IUserService
	{
		private readonly IDbContextFactory<FilmsContext> _dbContextFactory;
		private const int usualUserId = 1;

		public UserService(IDbContextFactory<FilmsContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		public async Task<int> CreateUserAsync(string email)
		{
			try
			{
				using(FilmsContext context = _dbContextFactory.CreateDbContext())
				{
					var user = new User { Email = email };

					user.Roles.Add(new UserRoles()
					{
						RoleId = 1
					});

					await context.Users.AddAsync(user);
					await context.SaveChangesAsync();

					return user.Id;
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
					return await context.Users
						.Include(x => x.Roles)
						.FirstOrDefaultAsync(u => u.Email == email);
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

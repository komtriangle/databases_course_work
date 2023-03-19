using FilmsApp.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmsApp.WebApi.Controllers
{

	[Route("[controller]")]
	public class UsersController: Controller
	{
		private readonly IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService
				?? throw new ArgumentNullException(nameof(userService));
		}


		[HttpGet("GetRoles")]
		public async  Task<IActionResult> GetUserRoles(int id)
		{
			try
			{
				var roles = await _userService.GetUserRolesAsync(id);

				if(roles == null)
				{
					return NotFound($"Пользователь с Id: {id} не найден");
				}

				return Ok(roles);
			}
			catch (Exception ex)
			{
				return BadRequest("Ошибка по время поиска ролей пользователя");
			}
		}

		[HttpPost("AddRoleToUser")]
		public async Task<IActionResult> AddRoleToUser(int userId, int roleId)
		{
			try
			{
				await _userService.AddRoleToUserAsync(userId, roleId);

				return Ok("Роль добавлена");
			}
			catch(Exception ex)
			{
				return BadRequest("Ошибка по время добавления роль");
			}
		}
	}
}

using FilmsApp.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FilmsApp.WebApi.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace FilmsApp.WebApi.Controllers
{

	[Route("[controller]")]
	public class UsersController: Controller
	{
		private readonly IUserService _userService;
		private readonly ILogger<UsersController> _logger;

		public UsersController(IUserService userService,
			ILogger<UsersController> logger)
		{
			_userService = userService
				?? throw new ArgumentNullException(nameof(userService));
			_logger = logger
				?? throw new ArgumentNullException(nameof(logger));
		}

		[HttpGet("GetUserInfo")]
		[Authorize]
		public async Task<IActionResult> GetUserInfo()
		{
			return Ok(new
			{
				UserId = User.FindFirst("UserId")?.Value,
				Roles = (User.FindFirst("RolesId")?.Value ?? string.Empty).Split(',').ToArray()
			});
		}


		[HttpGet("GetRoles")]
		[Authorize]
		public async  Task<IActionResult> GetUserRoles(int id)
		{
			_logger.LogInformation($"Запрос от пользователя: {User.GetUserName()} на получение списка ролей " +
				$"пользователя с Id: {id}");
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
				_logger.LogError(ex, $"Ошибка во время получения списка ролея пользователя с Id: {id}");
				return BadRequest("Ошибка по время поиска ролей пользователя");
			}
		}

		[HttpPost("AddRoleToUser")]
		public async Task<IActionResult> AddRoleToUser(int userId, int roleId)
		{
			_logger.LogInformation($"Запрос от пользователя: {User.GetUserName()} на добавление роли: {roleId} " +
				$"пользователю: {userId}");
			try
			{
				await _userService.AddRoleToUserAsync(userId, roleId);

				return Ok("Роль добавлена");
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, $"Ошибка во время добавления роли: {roleId} пользователю: {userId}");
				return BadRequest("Ошибка по время добавления роль");
			}
		}
	}
}

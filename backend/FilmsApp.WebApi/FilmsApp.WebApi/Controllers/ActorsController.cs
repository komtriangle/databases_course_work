using FilmsApp.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using FilmsApp.WebApi.Exceptions;

namespace FilmsApp.WebApi.Controllers
{
	[System.Web.Http.Route("[controller]")]
	[Authorize]
	public class ActorsController : Controller
	{
		private readonly IActorService _actorService;
		private readonly ILogger<ActorsController> _logger;

		public ActorsController(IActorService actorService,
			ILogger<ActorsController> logger)
		{
			_actorService = actorService 
				?? throw new ArgumentNullException(nameof(actorService));
			_logger = logger 
				?? throw new ArgumentNullException(nameof(logger));
		}

		[Microsoft.AspNetCore.Mvc.HttpGet("GetActors")]
		public async Task<IActionResult> GetActors(string searchQuery, int count = 20, int offset = 0)
		{
			_logger.LogInformation($"Запрос от пользователя: {User.GetUserName()} на получение списка актеров");
			try
			{
				return Ok(await _actorService.GetActorsAsync(searchQuery, count, offset));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка во время запроса на получение актеров");
				return BadRequest("Ошибка во время поиска актеров");
			}
		}
	}
}

using FilmsApp.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace FilmsApp.WebApi.Controllers
{
	[System.Web.Http.Route("[controller]")]
	[Authorize]
	public class ActorsController : Controller
	{
		private readonly IActorService _actorService;

		public ActorsController(IActorService actorService)
		{
			_actorService = actorService 
				?? throw new ArgumentNullException(nameof(actorService));
		}

		[Microsoft.AspNetCore.Mvc.HttpGet("GetActors")]
		public async Task<IActionResult> GetActors(string searchQuery, int count = 20, int offset = 0)
		{
			try
			{
				return Ok(await _actorService.GetActors(searchQuery, count, offset));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return BadRequest("Ошибка во время поиска актеров");
			}
		}
	}
}

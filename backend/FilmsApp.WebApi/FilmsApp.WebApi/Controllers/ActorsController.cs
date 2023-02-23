using Microsoft.AspNetCore.Mvc;

namespace FilmsApp.WebApi.Controllers
{
	public class ActorsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

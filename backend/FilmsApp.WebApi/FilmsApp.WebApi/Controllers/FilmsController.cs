using FilmsApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmsApp.WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FilmsController : Controller
	{

		private readonly IDbContextFactory<FilmsContext> _filmsContextFactory;
		public FilmsController(IDbContextFactory<FilmsContext> filmsContextFactory)
		{
			_filmsContextFactory = filmsContextFactory;
		}

		[HttpGet("test")]
		public IActionResult GetTest()
		{

			using(FilmsContext context = _filmsContextFactory.CreateDbContext())
			{
				var countries = context.Countries.ToArray();
			}
			return Json("");
		}
	}
}

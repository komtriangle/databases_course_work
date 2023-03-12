using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmsApp.WebApi.Controllers
{
	public class AuthController: Controller
	{
		//private readonly IDbContextFactory<FilmsContext> dbContextFactory;

		public IActionResult GetRoles()
		{
			return Ok();
		}
	}
}

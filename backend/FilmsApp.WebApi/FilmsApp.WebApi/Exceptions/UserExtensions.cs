using System.Security.Claims;

namespace FilmsApp.WebApi.Exceptions
{
	public static class UserExtensions
	{
		public static string GetUserName(this ClaimsPrincipal user)
		{
			if (!string.IsNullOrWhiteSpace(user?.Identity?.Name))
			{
				return user.Identity.Name;
			}

			return "Аноним";
		}
	}
}

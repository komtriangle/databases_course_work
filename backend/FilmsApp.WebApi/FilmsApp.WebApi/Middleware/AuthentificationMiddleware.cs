using Google.Apis.Auth;
using System.Security.Principal;

namespace FilmsApp.WebApi.Middlewarer
{
	public class AuthentificationMiddleware
	{
        private readonly RequestDelegate _next;

        public AuthentificationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            GoogleJsonWebSignature.ValidationSettings settings = new GoogleJsonWebSignature.ValidationSettings();

            settings.Audience = new List<string>() { "1006300932308-v47i976nval32vprp2586355p4n4fuib.apps.googleusercontent.com" };

			try
			{
                if(context.Request.Headers.TryGetValue("Authorization", out var authHeaderValues))
                {
                    var authHeaderValue = authHeaderValues.FirstOrDefault();
                   
                }
            }
            catch (Exception ex)
			{

			}
          
            await _next(context);
        }
    }
}

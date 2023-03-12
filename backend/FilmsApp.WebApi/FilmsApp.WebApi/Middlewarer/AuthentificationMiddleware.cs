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
            
        }
    }
}

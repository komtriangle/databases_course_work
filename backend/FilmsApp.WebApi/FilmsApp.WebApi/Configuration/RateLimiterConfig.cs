namespace FilmsApp.WebApi.Configuration
{
	public class RateLimiterConfig
	{
		public TimeSpan WindowLength { get; set; }
		public int MaxRequestsPerWindow { get; set; }
	}
}

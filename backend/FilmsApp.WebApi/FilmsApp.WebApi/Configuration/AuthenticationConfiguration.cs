namespace FilmsApp.WebApi.Configuration
{
	public class AuthenticationConfiguration
	{
		public GoogleAuthConfiguration Google { get; set; }
	}

	public class GoogleAuthConfiguration
	{
		public string ClientId { get; set; }
}

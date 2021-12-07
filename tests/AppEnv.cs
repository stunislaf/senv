using SimpleEnv;

namespace Tests
{
	public class AppEnv
	{
		[EnvVar("")]
		public EnvHostVar? Host { get; set; }

		[EnvVar("TOKEN")]
		public string? Token { get; set; }

		[EnvVar("DEBUG")]
		public bool Debug { get; set; }
	}
}

using SimpleEnv;

namespace Tests
{
	public static class StaticAppEnv
	{
		[EnvVar("")]
		public static EnvHostVar? Host { get; set; }

		[EnvVar("TOKEN")]
		public static string? Token { get; set; }

		[EnvVar("DEBUG")]
		public static bool Debug { get; set; }
	}
}

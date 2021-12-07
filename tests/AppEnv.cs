using SimpleEnv;

namespace Tests
{
	public class AppEnv
	{
		[EnvVar("")]
		public EnvHostVar? Host;

		[EnvVar("TOKEN")]
		public string? Token { get; set; }

		[EnvVar("FILE_TOKEN")]
		public string? FileToken { get; set; }

		[EnvVar("DEBUG")]
		public bool Debug { get; set; }
		
		[EnvVar("FILE_DEBUG")]
		public bool FileDebug { get; set; }
	}
}

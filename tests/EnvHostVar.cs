using SimpleEnv;

namespace Tests
{
	public class EnvHostVar
	{
		[EnvVar("NAME")]
		public string? Name { get; set; }

		[EnvVar("PORT")]
		public int Port { get; set; }

		[EnvVar("DNAME", DefaultValue = "0.0.0.0")]
		public string? DefaultName { get; set; }

		[EnvVar("FILE_NAME")]
		public string? FileName { get; set; }

		[EnvVar("FILE_PORT")]
		public int FilePort { get; set; }
	}
}

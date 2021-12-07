using SimpleEnv;

namespace Tests
{
	public class EnvHostVar
	{
		[EnvVar("NAME")]
		public string? Name { get; set; }

		[EnvVar("DNAME", DefaultValue = "0.0.0.0")]
		public string? DefaultName { get; set; }

		[EnvVar("PORT")]
		public int Port { get; set; }

	}
}

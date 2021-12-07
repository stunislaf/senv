using System;
using Xunit;

namespace Tests
{
	public class EnvTest
	{
		private (string hostName, int hostPort, string token, bool debug) InitProcessEnv()
		{
			var hostName = "localhost";
			var hostPort = 8080;
			var token = "JXT-X";
			var debug = true;

			Environment.SetEnvironmentVariable("NAME", hostName);
			Environment.SetEnvironmentVariable("PORT", hostPort.ToString());
			Environment.SetEnvironmentVariable("TOKEN", token);
			Environment.SetEnvironmentVariable("DEBUG", debug.ToString());

			return (hostName, hostPort, token, debug);
		}

		[Fact]
		public void Fill()
		{
			var (hostName, hostPort, token, debug) = InitProcessEnv();

			var env = new AppEnv();
			SimpleEnv.Env.Fill(ref env);

			Assert.Equal(hostName, env.Host!.Name);
			Assert.Equal("0.0.0.0", env.Host.DefaultName);
			Assert.Equal(hostPort, env.Host.Port);
			Assert.Equal(token, env.Token);
			Assert.Equal(debug, env.Debug);
		}

		[Fact]
		public void FillStaticClass()
		{
			var (hostName, hostPort, token, debug) = InitProcessEnv();

			SimpleEnv.Env.FillStaticClass(typeof(StaticAppEnv));

			Assert.Equal(hostName, StaticAppEnv.Host!.Name);
			Assert.Equal("0.0.0.0", StaticAppEnv.Host.DefaultName);
			Assert.Equal(hostPort, StaticAppEnv.Host.Port);
			Assert.Equal(token, StaticAppEnv.Token);
			Assert.Equal(debug, StaticAppEnv.Debug);
		}
	}
}

## Install

`dotnet add package SimpleEnv`

## Examples

Example for static classes:

```c#
private static class AppEnv
{
    [EnvVar("PORT", DefaultValue = 8080)]
    public static int Port { get; set; }

    [EnvVar("JWT_KEY")]
    public static string JwtKey { get; set; }
}

Env.FillStaticClass(typeof(AppEnv));

```

Example for ref:

```c#
private class AppEnv
{
    [EnvVar("PORT", DefaultValue = 8080)]
    public int Port { get; set; }

    [EnvVar("JWT_KEY")]
    public string JwtKey { get; set; }
}

var appEnv = new AppEnv(); // or just AppEnv appEnv = null;
Env.Fill(ref appEnv);

```

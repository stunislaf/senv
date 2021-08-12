using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace SimpleEnv
{
	public static class Env
	{
		private const BindingFlags Flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.IgnoreCase;
		private static Dictionary<string, object> _env = new();

		public static void FillStaticClass(Type type)
		{
			if (!(type.IsAbstract && type.IsSealed))
				throw new InvalidOperationException("type not static class");

			_env = null;

			var props = type.GetProperties(Flags);

			foreach (var prop in props)
				FillProp(prop, null);
		}

		public static void Fill<T>(ref T obj) where T : class
		{
			obj ??= (T)Activator.CreateInstance(typeof(T));

			Debug.Assert(obj != null, nameof(obj) + " != null");

			_env = null;

			var props = obj.GetType().GetProperties(Flags);

			foreach (var prop in props)
				FillProp(prop, obj);
		}

		private static void FillProp(PropertyInfo prop, object obj)
		{
			if (prop.PropertyType.IsClass && prop.PropertyType != typeof(string))
			{
				try
				{
					var val = Activator.CreateInstance(prop.PropertyType);
					Fill(ref val);
					prop.SetValue(obj, val);
				}
				catch (Exception)
				{
					return;
				}
			}

			var ignoreAttr = prop.GetCustomAttribute<IgnoreEnv>();
			if (ignoreAttr != null)
				return;

			var attr = prop.GetCustomAttribute<EnvVar>();
			if (attr == null)
				return;

			(_env ?? (_env = GetEnv())).TryGetValue(attr.Name.ToUpper(), out var envVal);

			if (envVal == null)
				return;

			try
			{
				var val = Convert.ChangeType(envVal, prop.PropertyType);
				prop.SetValue(obj, val);
			}
			catch (Exception)
			{
				// ignored
			}
		}

		private static Dictionary<string, object> GetEnv()
		{
			var d = new Dictionary<string, object>();
			var variables = Environment.GetEnvironmentVariables();
			foreach (DictionaryEntry variable in variables)
				d[variable.Key.ToString().ToUpper()] = variable.Value;
			return d;
		}
	}
}

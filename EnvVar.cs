using System;

namespace SimpleEnv
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EnvVar : Attribute
    {
        public EnvVar(string name) => Name = name;

        public string Name { get; set; }

        public object DefaultValue { get; set; } = null;
    }
}

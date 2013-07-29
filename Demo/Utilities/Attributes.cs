using System;

namespace Demo
{
    [Serializable, AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class OptionalAttribute : Attribute { }
}

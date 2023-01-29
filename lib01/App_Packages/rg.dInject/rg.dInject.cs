using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace rg
{
    [Conditional("DEBUG")]
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class DInject : Attribute
    {
        public DInject() { }
        public DInject(string key) { }

        public bool IsLazy { get; set; }
    }
}
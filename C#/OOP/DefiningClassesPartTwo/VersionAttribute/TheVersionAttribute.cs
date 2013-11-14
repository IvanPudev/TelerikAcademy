using System;
using System.Linq;

namespace VersionAttribute
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface |
        AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)]
    class TheVersionAttribute : System.Attribute
    {
        public string Version { get; private set; }

        public TheVersionAttribute(string version)
        {
            this.Version = version;
        }
    }
}

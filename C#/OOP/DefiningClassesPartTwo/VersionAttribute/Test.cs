using System;
using System.Linq;

namespace VersionAttribute
{
    [TheVersion("1.0")]
    class Test 
    {
        static void Main(string[] args)
        {
            Type type = typeof(Test);
            object[] versionType = type.GetCustomAttributes(false);
            Console.WriteLine("Class version is {0}.", ((TheVersionAttribute)versionType[0]).Version);
        }
    }
}

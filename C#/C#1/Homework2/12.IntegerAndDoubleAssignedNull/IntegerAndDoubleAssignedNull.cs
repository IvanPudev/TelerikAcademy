using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.IntegerAndDoubleAssignedNull
{
    class IntegerAndDoubleAssignedNull
    {
        static void Main(string[] args)
        {
            int? intNull = null;
            double? doubleNull = null;
            Console.WriteLine(intNull);
            Console.WriteLine(doubleNull);
            intNull = 5;
            doubleNull = 10;
            Console.WriteLine(intNull);
            Console.WriteLine(doubleNull);
        }
    }
}

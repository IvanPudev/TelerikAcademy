using System;
using System.Linq;

namespace PerformanceTestOfCommonMathOperations
{
    class Test
    {
        static void Main()
        {
            Add.AddDecimal(4m, 500000m);
            Add.AddDouble(4d, 500000d);
            Add.AddFloat(4f, 500000f);
            Add.AddInt(4, 500000);
            Add.AddLong(4L, 500000L);

            Substract.SubstractDecimal(500000m, 4m);
            Substract.SubstractDouble(500000d, 4d);
            Substract.SubstractFloat(500000f, 4f);
            Substract.SubstractInt(500000, 4);
            Substract.SubstractLong(500000L, 4L);

            Multiply.MultiplyDecimal(2m, 500000m, 2m);
            Multiply.MultiplyDouble(2d, 500000d, 5d);
            Multiply.MultiplyFloat(2f, 500000f, 5f);
            Multiply.MultiplyInt(2, 500000, 5);
            Multiply.MultiplyLong(2L, 500000L, 5L);

            Divide.DivideDecimal(500000m, 4m, 2m);
            Divide.DivideDouble(500000d, 4d, 2d);
            Divide.DivideFloat(500000f, 4f, 2f);
            Divide.DivideInt(500000, 4, 2);
            Divide.DivideLong(500000L, 4L, 2L);
        }
    }
}
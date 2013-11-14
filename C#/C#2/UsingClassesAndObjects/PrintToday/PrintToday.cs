using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintToday
{
    class PrintToday
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Now;
            Console.WriteLine("Today is  {0}.", today.DayOfWeek);
        }
    }
}

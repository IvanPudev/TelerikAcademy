using System;
using System.Linq;

namespace Persons
{
    class TestExecutable
    {
        static void Main()
        {
            Person firstPerson = new Person("Pesho", 26);
            Person secondPerson = new Person("Gosho", null);
            Person thirdPerson = new Person("Misho");
            Console.WriteLine(firstPerson);
            Console.WriteLine(secondPerson);
            Console.WriteLine(thirdPerson);

        }
    }
}

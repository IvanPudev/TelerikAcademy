using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    class Executable
    {
        static void Main()
        {
            List<Animal> animalList = new List<Animal>()
            {
                new Frog("Jaba", 1, Enum.Gender.Female),
                new Dog("Pesho", 3, Enum.Gender.Male),
                new Kitten("Miss", 2, Enum.Gender.Female),
                new TomCat("Tom", 6, Enum.Gender.Female),
                new Cat("Princess", 8, Enum.Gender.Male),
            };

            var averageAge = animalList.Average(x => x.Age);
            Console.WriteLine(averageAge);

            Dog dog = new Dog("Pirin", 3 ,Enum.Gender.Male);
            Console.WriteLine(dog.MakeSound());
        }
    }
}

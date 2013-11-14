using System;
using System.Linq;

namespace Animals
{
    class Dog : Animal, Interface.ISound
    {
        public Dog(string name, short age, Enum.Gender sex)
            : base(name, age, sex)
        {
        }

        public string MakeSound()
        {
            return "Wraf Wraf";
        }
    }
}

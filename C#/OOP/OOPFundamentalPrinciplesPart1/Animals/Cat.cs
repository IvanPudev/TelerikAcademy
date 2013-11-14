using System;
using System.Linq;

namespace Animals
{
    class Cat : Animal, Interface.ISound
    {
        public Cat(string name, short age, Enum.Gender sex)
            : base(name, age, sex)
        {
        }

        public string MakeSound()
        {
            return "Meaouuuu";
        }
    }
}

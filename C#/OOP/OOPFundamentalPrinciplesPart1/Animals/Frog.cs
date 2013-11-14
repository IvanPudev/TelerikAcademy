using System;
using System.Linq;

namespace Animals
{
    class Frog : Animal, Interface.ISound
    {
        public Frog(string name, short age, Enum.Gender sex)
            : base(name, age, sex)
        {
        }

        public string MakeSound()
        {
            return "Quack Quack";
        }
    }
}

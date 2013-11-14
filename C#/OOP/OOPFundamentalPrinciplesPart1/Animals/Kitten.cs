using System;
using System.Linq;

namespace Animals
{
    class Kitten : Cat
    {
        public Kitten(string name, short age, Enum.Gender sex = Enum.Gender.Female)
            : base(name, age, sex)
        {
        }
    }
}

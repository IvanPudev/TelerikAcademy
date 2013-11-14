using System;
using System.Linq;

namespace Animals
{
    class TomCat : Cat
    {
        public TomCat(string name, short age, Enum.Gender sex = Enum.Gender.Male)
            : base(name, age, sex)
        {
        }
    }
}

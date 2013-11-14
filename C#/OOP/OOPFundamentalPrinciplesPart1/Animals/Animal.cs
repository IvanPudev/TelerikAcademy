using System;
using System.Linq;

namespace Animals
{
    abstract class Animal
    {
        private string name;
        private short age;
        private Enum.Gender sex;

        protected Animal(string name, short age, Enum.Gender sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public short Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public Enum.Gender Sex
        {
            get { return this.sex; }
            set { this.sex = value; }
        }
    }
}

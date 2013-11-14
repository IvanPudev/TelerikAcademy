using System;
using System.Linq;

namespace Persons
{
    class Person
    {
        public string Name { get; set; }
        public byte? Age { get; set; }

        public Person(string name, byte? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            string message = "Name: " + this.Name + " Age: ";
            if (this.Age == null)
            {
                message += "Not specified";
            }
            else
                message += this.Age;

            return message;
        }
    }
}

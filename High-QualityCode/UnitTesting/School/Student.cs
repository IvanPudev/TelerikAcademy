using System;
using System.Linq;

namespace School
{
    public class Student
    {
        private string name;
        private int uniqueID;

        public Student(string name, int uniqueId)
        {
            this.Name = name;
            this.UniqueID = uniqueId;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name must be entered.");
                }
                else
                {
                    this.name = value;
                }
            }

        }

        public int UniqueID
        {
            get
            {
                return this.uniqueID;
            }
            set
            {
                if (10000 < value || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("The ID must be between 10000 and 99999.");
                }
                else
                {
                    this.uniqueID = value;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("Student: {0}, ID: {1}; ", this.Name, this.UniqueID);
        }
    }
}

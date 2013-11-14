using System;
using System.Linq;

namespace Students
{
    class Student : ICloneable, IComparable<Student> 
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private int ssn;
        private string address;
        private string phone;
        private short course;
        private Enum.University university;
        private Enum.Faculty faculty;
        private Enum.Specialty specialty;

        public Student(string firstName, string middleName = null, string lastName, int ssn, string address = null,
            string phone = null, short course = null, Enum.University university = null, Enum.Faculty faculty = null, Enum.Specialty specialty = null)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.Address = address;
            this.Phone = phone;
            this.Course = course;
            this.University = university;
            this.Faculty = faculty;
            this.Specialty = specialty;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set { this.firstName = value; }
        }

        public string MiddleName
        {
            get { return this.middleName; }
            private set { this.middleName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set { this.lastName = value; }
        }

        public int SSN
        {
            get { return this.ssn; }
            private set { this.ssn = value; }
        }

        public string Address
        {
            get { return this.address; }
            private set { this.address = value; }
        }

        public string Phone
        {
            get { return this.phone; }
            private set { this.phone = value; }
        }

        public short Course
        {
            get { return this.course; }
            private set { this.course = value; }
        }

        public Enum.University University
        {
            get { return this.university; }
            private set { this.university = value; }
        }

        public Enum.Faculty Faculty
        {
            get { return this.faculty; }
            private set { this.faculty = value; }
        }

        public Enum.Specialty Specialty
        {
            get { return this.specialty; }
            private set { this.specialty = value; }
        }

        //Methosds override

        public override string ToString()
        {
            return string.Format("Student: {0} {1} {2}{10}SSN: {3}{10}Address: {4}{10}Phone: {5}{10}Course: {6}{10}University: {7} Faculty: {8} Specialty: {9}{10}",
                this.FirstName, this.MiddleName, this.LastName, this.SSN, this.Address, this.Phone, this.Course,
                this.University, this.Faculty, this.Specialty, Environment.NewLine);
        }

        public override bool Equals(object param)
        {
            Student student = param as Student;

            if (student == null)
            {
                return false;
            }
            if (!Object.Equals(this.FirstName, student.FirstName))
            {
                return false;
            }
            if (!Object.Equals(this.MiddleName, student.MiddleName))
            {
                return false;
            }
            if (!Object.Equals(this.LastName, student.LastName))
            {
                return false;
            }
            if (!Object.Equals(this.SSN, student.SSN))
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode() ^ SSN.GetHashCode();
        }

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            if (System.Object.ReferenceEquals(firstStudent, secondStudent))
            {
                return true;
            }
            if (((object)firstStudent == null) || ((object)secondStudent == null))
            {
                return false;
            }
            return firstStudent.Equals(secondStudent);
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return !(firstStudent == secondStudent);
        }

        public Student Clone()
        {
            return new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.Address,
                this.Phone, this.Course, this.University, this.Faculty, this.Specialty);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public int CompareTo(Student student)
        {
            if (this.FirstName != student.FirstName)
            {
                return (this.FirstName.CompareTo(student.FirstName));
            }
            if (this.MiddleName != student.MiddleName)
            {
                return (this.MiddleName.CompareTo(student.MiddleName));
            }
            if (this.LastName != student.LastName)
            {
                return (this.LastName.CompareTo(student.LastName));
            }
            if (this.SSN != student.SSN)
            {
                return (this.SSN - student.SSN);
            }
            return 0;
        }
    }
}

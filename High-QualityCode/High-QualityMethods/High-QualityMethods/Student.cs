using System;

namespace High_QualityMethods
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PersonalInfo PersonalInfo { get; set; }

        public bool IsOlderThan(Student student)
        {
            bool isOlder = false;
            DateTime firstStudent = this.PersonalInfo.BirthDate;
            DateTime secondStudent = student.PersonalInfo.BirthDate;

            if (DateTime.Compare(firstStudent, secondStudent) < 0)
            {
                isOlder = true;
            }

            return isOlder;
        }
    }
}
using System;
using System.Linq;

namespace Students
{
    class Methods
    {
        public static Student[] FirstBeforeLastName(Student[] students)
        {
            var result = from student in students
                         where student.FirstName.CompareTo(student.LastName) < 0
                         select student;
            return result.ToArray();
        }

        public static Student[] FirstAndLastNameInAgeInterval(Student[] students)
        {
            var result = from student in students
                         where student.Age >= 18 && student.Age <= 24
                         select student;
            return result.ToArray();
        }

        public static Student[] OrderByDescendingName(Student[] students)
        {
            var orderedStudents = students.OrderByDescending(name => name.FirstName)
                .ThenByDescending(name => name.LastName);
            return orderedStudents.ToArray();
        }

        public static Student[] OrderByNameDescending(Student[] students)
        {
            var orderedStudents = from student in students
                                  orderby student.FirstName, student.LastName descending
                                  select student;
            return orderedStudents.ToArray();                      
        }
    }
}

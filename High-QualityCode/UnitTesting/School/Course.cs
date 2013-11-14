using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    public class Course
    {
        public const int MaxStudents = 29;
        private List<Student> students = new List<Student>();
        private string name;

        public Course(string name, IEnumerable<Student> students)
        {
            this.Students = new List<Student>(students);
            this.Name = name;
        }

        public List<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                bool isIdUnique = IsIDUnique(value);

                if (!isIdUnique)
                {
                    throw new ArgumentException("ID must be unique.");
                }
                else if (value.Count > MaxStudents)
                {
                    throw new ArgumentOutOfRangeException("The course is full.");
                }
                else
                {
                    this.students = value;
                }
            }
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
                    throw new ArgumentNullException("The course must have name.");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public void AddStudent(Student newStudent)
        {
            bool isStudentUnique = IsIdUnique(newStudent);

            if (!isStudentUnique)
            {
                throw new ArgumentException("The ID must be unique foe each student.");
            }
            else if (this.students.Count + 1 > MaxStudents)
            {
                throw new ArgumentOutOfRangeException("Course limit reached.");
            }
            else
            {
                this.students.Add(newStudent);
            }
        }

        public void RemoveStudent(Student studentForRemove)
        {
            if (IsIdUnique(studentForRemove))
            {
                throw new ArgumentException("No student found.");
            }
            else
            {
                this.students.Remove(studentForRemove);
            }
        }

        public bool IsIdUnique(Student checkedStudent)
        {
            foreach (var student in this.Students)
            {
                if (student.UniqueID == checkedStudent.UniqueID)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsIDUnique(List<Student> students)
        {
            for (int index = 0; index < students.Count - 1; index++)
            {
                for (int indexToTheEnd = index + 1; indexToTheEnd < students.Count; indexToTheEnd++)
                {
                    if (students[index].UniqueID == students[indexToTheEnd].UniqueID)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

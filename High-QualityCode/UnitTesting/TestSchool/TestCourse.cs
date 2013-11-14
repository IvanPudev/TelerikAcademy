using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace TestSchool
{
    [TestClass]
    public class TestCourse
    {
        [TestMethod]
        public void TestTheConstructorCourseName()
        {
            List<Student> myColeges = new List<Student>(){ 
            new Student("Pesho",10001),
            new Student("Gosho", 10101)
            };
            Course myCourse = new Course("C#", myColeges);
            Assert.AreEqual("C#", myCourse.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAllStudentsHaveUniqueNumber()
        {
            List<Student> myColeges = new List<Student>(){ 
            new Student("Pesho",20010),
            new Student("Gosho", 20010)
            };
            Course myCourse = new Course("C#", myColeges);
        }

        [TestMethod]
        public void TestAddStudent()
        {
            List<Student> myColeges = new List<Student>(){ 
            new Student("Pesho",20011),
            new Student("lol", 20010)
            };

            Course myCourse = new Course("C#", myColeges);
            Student newStudent = new Student("Gosho", 20012);

            myCourse.AddStudent(newStudent);
            int getLastStudentNumber = myCourse.Students.Count - 1;
            Assert.AreEqual("Misho", myCourse.Students[getLastStudentNumber].Name);
        }

        [TestMethod]
        public void TestRemoveStudend()
        {
            Student testStudent = new Student("Pesho", 20012);
            List<Student> myColeges = new List<Student>(){ 
            new Student("Pesho",20011),
            new Student("lol", 20010),
            };

            Course myCourse = new Course("C#", myColeges);
            myCourse.AddStudent(testStudent);
            myCourse.RemoveStudent(testStudent);

            bool isThereThatStudent = false;
            foreach (var student in myCourse.Students)
            {
                if (student.UniqueID == testStudent.UniqueID)
                {
                    isThereThatStudent = true;
                }
            }

            Assert.AreEqual(false, isThereThatStudent);
            Assert.AreEqual(2, myCourse.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveStudendIfThereNoSuchStudent()
        {
            Student testStudent = new Student("Misho", 20012);
            List<Student> myColeges = new List<Student>(){ 
            new Student("Pesho",20011),
            new Student("Gosho", 20010),
            };

            Course myCourse = new Course("C#", myColeges);
            myCourse.RemoveStudent(testStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestReachLimitOfTheCourse()
        {
            List<Student> myColeges = new List<Student>(){ 
            new Student("Pesho",20010),
            new Student("Gosho", 20000)
            };
            int uniqueId = 30000;
            Course myCourse = new Course("C#", myColeges);
            for (int i = 0; i < 29; i++)
            {
                uniqueId++;
                Student newStudent = new Student("Misho", uniqueId);
                myCourse.AddStudent(newStudent);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestConstructorMoreStudentsSignUpThenMaximum()
        {
            List<Student> myColeges = new List<Student>(){ 
            new Student("Pesho",20010),
            new Student("Gosho", 20000)
            };
            int uniqueId = 30000;
            for (int i = 0; i < 29; i++)
            {
                uniqueId++;
                Student newStudent = new Student("ivane", uniqueId);
                myColeges.Add(newStudent);
            }
            Course myCourse = new Course("C#", myColeges);
        }
    }
}

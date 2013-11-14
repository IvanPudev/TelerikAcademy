using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace TestSchool
{
    [TestClass]
    public class TestStudent
    {
        [TestMethod]
        public void TestTheConstructorStudentName()
        {
            Student newStudent = new Student("Gosho", 10001);
            Assert.AreEqual("Gosho", newStudent.Name);
        }

        [TestMethod]
        public void TestTheConstructorStudentUniqueNumber()
        {
            Student newStudent = new Student("Gosho", 20020);
            Assert.AreEqual(20020U, newStudent.UniqueID);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorStudentNameEmpty()
        {
            Student newStudent = new Student("", 100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorStudentNameNull()
        {
            Student newStudent = new Student(null, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestConstructorStudentUniqueNumberInBoundary()
        {
            Student newStudent = new Student("Pesho", 100);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsAndWorkers
{
    class Executable
    {
        static void Main()
        {
            List<Student> studentsList = new List<Student>()
            {
                new Student("Pencho","Penchev", 5),
                new Student("Pencho","Minchev", 3),
                new Student("Ivan","Petrov", 5.50),
                new Student("Alexander","Alexandrov", 5.25),
                new Student("Georgy","Kolev", 4),
                new Student("Kiril","Vachev", 5),
                new Student("Gancho","Milev", 5.40),
                new Student("John","Smith", 6),
                new Student("Gandalf","Gray", 5.20),
                new Student("Frodo","Baggins", 3.60),
            };

            var sortedStudents = studentsList.OrderBy(x => x.Grade);
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            List<Worker> workersList = new List<Worker>()
            {
                new Worker("Mister","Anderson", 400M, 8),
                new Worker("Morpheous","Moroh", 500M, 8),
                new Worker("Johnatan","Livingston", 360M, 12),
                new Worker("Mobby","Dick", 520M, 10),
                new Worker("Uncle","Sam", 450M, 9),
                new Worker("The","Matrix", 5000M, 23),
                new Worker("Mr","T", 540M, 8),
                new Worker("Clark","Kent", 600M, 18),
                new Worker("Nature","Boy", 520M, 8),
                new Worker("Bruce","Wane", 1000, 10),
            };

            var sortedWorkers = workersList.OrderByDescending(x => x.MoneyPerHour());
            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine(worker);
            }
            Console.WriteLine();

            var mergedLists = sortedStudents.Concat<Human>(sortedWorkers)
                .OrderBy(x => x.FirstName)
                .ThenBy(y => y.LastName);
            foreach (var human in mergedLists)
            {
                Console.WriteLine(human);
            }
        }
    }
}

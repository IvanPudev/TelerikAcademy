using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    public class School
    {
        public List<Course> Courses { get; set; }

        public School(IEnumerable<Course> courses)
        {

            if (!IsAllIdUnique(new List<Course>(courses)))
            {
                throw new ArgumentException("Not all students have the uniqueNumber");
            }
            else
            {
                this.Courses = new List<Course>(courses);
            }
        }

        public bool IsAllIdUnique(List<Course> allCourses)
        {
            for (int indexCheckedCourse = 0; indexCheckedCourse < allCourses.Count - 1; indexCheckedCourse++)
            {
                for (int otherIndex = indexCheckedCourse + 1; otherIndex < allCourses.Count; otherIndex++)
                {
                    foreach (var checkedItem in allCourses[indexCheckedCourse].Students)
                    {
                        foreach (var item in allCourses[otherIndex].Students)
                        {
                            if (checkedItem.UniqueID == item.UniqueID)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}

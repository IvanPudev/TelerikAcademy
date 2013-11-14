using System;
using System.Linq;

namespace School
{
    class Discipline
    {
        private Enum.DisciplineName name;
        private int lectureNumber;
        private int exerciseNumber;

        public Discipline(Enum.DisciplineName name, int lectureNumber, int exerciseNumber)
        {
            this.Name = name;
            this.LectureNumber = lectureNumber;
            this.ExerciseNumber = exerciseNumber;
        }

        public Enum.DisciplineName Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int LectureNumber
        {
            get { return this.lectureNumber; }
            private set { this.lectureNumber = value; }
        }

        public int ExerciseNumber
        {
            get { return this.exerciseNumber; }
            private set { this.exerciseNumber = value; }
        }
    }
}

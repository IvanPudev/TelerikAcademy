using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    class Teacher : Human, Interface.ICommentable
    {
        private List<Discipline> disciplines;
        private string comment;

        public Teacher(string firstName, string lastName,List<Discipline> disciplines, string comment = null)
            : base(firstName, lastName)
        {
            this.Disciplines = disciplines;
            this.Comment = comment;
        }

        public List<Discipline> Disciplines
        {
            get { return this.disciplines; }
            set { this.disciplines = value; }
        }

        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }
    }
}

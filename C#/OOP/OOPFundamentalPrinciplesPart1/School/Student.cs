using System;
using System.Linq;

namespace School
{
    class Student : Human, Interface.ICommentable
    {
        private string id;
        private string comment;

        public Student(string firstName, string lastName, string id, string comment = null)
            : base(firstName, lastName)
        {
            this.ID = id;
            this.Comment = comment;
        }

        public string ID
        {
            get { return this.id; }
            private set { this.id = value; }
        }

        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }
    }
}

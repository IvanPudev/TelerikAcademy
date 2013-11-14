using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    class Class : Interface.ICommentable
    {
        #region Fields

        private Enum.ClassIdentifier classIdentifier;
        private List<Teacher> setTeachers;
        private string comment;

        #endregion

        #region Constructor

        public Class(Enum.ClassIdentifier classId, List<Teacher> setTeachers, string comment = null)
        {
            this.ClassID = classId;
            this.SetTeacher = setTeachers;
            this.Comment = comment;
        }

        #endregion

        #region Properties

        public Enum.ClassIdentifier ClassID
        {
            get { return this.classIdentifier; }
            private set { this.classIdentifier = value; }
        }

        public List<Teacher> SetTeacher
        {
            get { return this.setTeachers; }
            private set { this.setTeachers = value; }
        }

        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }

        #endregion
    }
}

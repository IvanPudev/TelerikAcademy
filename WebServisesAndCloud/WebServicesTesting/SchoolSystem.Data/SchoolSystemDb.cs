using SchoolSystem.Model;
using System;
using System.Data.Entity;
using System.Linq;


namespace SchoolSystem.Data
{
    public class SchoolSystemDb : DbContext
    {
        public SchoolSystemDb()
            : base("SchoolSystemDb")
        {
            
        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Mark> Marks { get; set; }
    }
}

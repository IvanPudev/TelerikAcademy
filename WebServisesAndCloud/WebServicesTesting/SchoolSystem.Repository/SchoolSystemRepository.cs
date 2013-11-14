using System;
using System.Linq;
using SchoolSystem.Repository.Interfaces;
using System.Data.Entity;
using SchoolSystem.Data;
using SchoolSystem.Data.Migrations;

namespace SchoolSystem.Repository
{
    public class SchoolSystemRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext dbContext;
        private readonly DbSet<T> entitySet;

        public SchoolSystemRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<T>();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolSystemDb, Configuration>());
        }

        //implemented
        public T Add(T item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();
            return item;
        }

        public T Update(int id, T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        //implemented
        public T Get(int id)
        {
            return this.entitySet.Find(id);
        }

        //implemented
        public IQueryable<T> All()
        {
            return this.entitySet;
        }

        public IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}

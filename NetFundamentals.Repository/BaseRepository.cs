using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace NetFundamentals.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private NorthwindContext dbContext;
        public BaseRepository()
        {
            dbContext = new NorthwindContext();
        }
        public int Add(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Added;
            return dbContext.SaveChanges();
        }

        public int Delete(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Deleted;
            return dbContext.SaveChanges();
        }
        public int Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            return dbContext.SaveChanges();
        }
        public IEnumerable<T> GetList()
        {
            return dbContext.Set<T>();
        }

        public T GetById(Expression<Func<T, bool>> match)
        {
            return dbContext.Set<T>().FirstOrDefault(match);
        }
    }
}

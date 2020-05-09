using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using BankCP.Models.DBContext;
using BankCP.Modules.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace BankCP.Modules.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BankContext dbContext;
        private readonly DbSet<T> dbSet;

        public Repository(BankContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> List()
        {
            return dbSet.AsEnumerable();
        }

        public virtual IEnumerable<T> List(Expression<Func<T, bool>> predicate)
        {
            return dbSet
                    .Where(predicate)
                    .AsEnumerable();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
            dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}

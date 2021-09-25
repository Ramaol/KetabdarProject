using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Zero_Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Zero_Framework.Infrastructure
{
    public class Repository<TKey, T> : IRepository<TKey, T> where T : class
    {
        
        private readonly DbContext _Context;

        public Repository(DbContext context)
        {
            _Context = context;
        }
        public void Create(T entity)
        {
            _Context.Add(entity);
        }

        public bool Exist(Expression<Func<T, bool>> expression)
        {
            return _Context.Set<T>().Any(expression);
        }

        public T Get(TKey id)
        {
            return _Context.Find<T>(id);
        }

        public List<T> GetAll()
        {
            return _Context.Set<T>().ToList();
        }

        public void SaveChanges()
        {
            _Context.SaveChanges();
        }
    }
}

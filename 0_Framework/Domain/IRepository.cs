using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Zero_Framework.Domain
{
    public interface IRepository<TKey , T> where T : class
    {
        T Get(TKey id);
        List<T> GetAll();
        void Create(T entity);
        bool Exist(Expression<Func<T,bool>> expression);
        void SaveChanges();

    }
}

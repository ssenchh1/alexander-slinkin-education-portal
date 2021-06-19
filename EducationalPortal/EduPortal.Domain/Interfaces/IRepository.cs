using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EduPortal.Domain.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T obj);

        void Update(T obj);

        void Delete(T obj);

        T GetById(int id);

        IEnumerable<T> Get(Expression<Func<T, bool>> filter);
    }
}

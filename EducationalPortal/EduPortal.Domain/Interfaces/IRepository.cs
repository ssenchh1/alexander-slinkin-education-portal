using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EduPortal.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task Add(T obj);

        Task Update(T obj);

        Task Delete(T obj);

        Task<T> GetById(int id);

        IQueryable<T> Get(Expression<Func<T, bool>> filter);
    }
}

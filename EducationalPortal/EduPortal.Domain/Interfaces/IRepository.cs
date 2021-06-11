using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EduPortal.Domain.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T obj);

        void Update(T obj);

        void Delete(T obj);

        IEnumerable<T> GetAll();

        T GetById(int id);

        IEnumerable<T> Get(Expression<Func<T, bool>> filter);
    }
}

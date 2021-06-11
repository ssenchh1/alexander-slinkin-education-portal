using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models.Materials;
using EduPortal.Infrastructure.Context;

namespace EduPortal.Infrastructure.Repositories
{
    public class DigitalBookRepository : IDigitalBookRepository
    {
        private EducationalPortalContext db;

        public DigitalBookRepository(EducationalPortalContext context)
        {
            db = context;
        }

        public void Add(DigitalBook obj)
        {
            db.DigitalBooks.Add(obj);
            db.SaveChanges();
        }

        public void Update(DigitalBook obj)
        {
            db.DigitalBooks.Update(obj);
            db.SaveChanges();
        }

        public void Delete(DigitalBook obj)
        {
            db.DigitalBooks.Remove(obj);
            db.SaveChanges();
        }

        public IEnumerable<DigitalBook> GetAll()
        {
            return db.DigitalBooks;
        }

        public DigitalBook GetById(int id)
        {
            return db.DigitalBooks.First(b => b.Id == id);
        }

        public IEnumerable<DigitalBook> Get(Expression<Func<DigitalBook, bool>> filter)
        {
            IQueryable<DigitalBook> query = db.DigitalBooks;

            query = query.Where(filter);

            return query;
        }
    }
}

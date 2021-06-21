using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models.Materials;
using EduPortal.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EduPortal.Infrastructure.Repositories
{
    public class DigitalBookRepository : IRepository<DigitalBook>
    {
        private EducationalPortalContext db;

        public DigitalBookRepository(EducationalPortalContext context)
        {
            db = context;
        }

        public async Task Add(DigitalBook obj)
        {
            await db.DigitalBooks.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task Update(DigitalBook obj)
        {
            db.DigitalBooks.Update(obj);
            await db.SaveChangesAsync();
        }

        public async Task Delete(DigitalBook obj)
        {
            db.DigitalBooks.Remove(obj);
            await db.SaveChangesAsync();
        }

        public async Task<DigitalBook> GetById(int id)
        {
            return await db.DigitalBooks.FirstAsync(b => b.Id == id);
        }

        public IQueryable<DigitalBook> Get(Expression<Func<DigitalBook, bool>> filter)
        {
            IQueryable<DigitalBook> query = db.DigitalBooks;

            query = query.Where(filter);

            return query;
        }
    }
}

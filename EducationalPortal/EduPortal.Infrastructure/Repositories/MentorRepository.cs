using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models.Users;
using EduPortal.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EduPortal.Infrastructure.Repositories
{
    public class MentorRepository : IRepository<Mentor>
    {
        private EducationalPortalContext db;

        public MentorRepository(EducationalPortalContext dbcontext)
        {
            db = dbcontext;
        }


        public async Task Add(Mentor obj)
        {
            await db.Mentors.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task Update(Mentor obj)
        {
            db.Mentors.Update(obj);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Mentor obj)
        {
            db.Mentors.Remove(obj);
            await db.SaveChangesAsync();
        }

        public async Task<Mentor> GetById(int id)
        {
            return await db.Mentors.FirstAsync(m => m.Id == id);
        }

        public IQueryable<Mentor> Get(Expression<Func<Mentor, bool>> filter)
        {
            IQueryable<Mentor> query = db.Mentors;

            query = query.Where(filter);

            return query;
        }
    }
}

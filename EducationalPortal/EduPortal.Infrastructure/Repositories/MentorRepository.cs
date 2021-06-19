using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models.Users;
using EduPortal.Infrastructure.Context;

namespace EduPortal.Infrastructure.Repositories
{
    public class MentorRepository : IRepository<Mentor>
    {
        private EducationalPortalContext db;

        public MentorRepository(EducationalPortalContext dbcontext)
        {
            db = dbcontext;
        }


        public void Add(Mentor obj)
        {
            db.Mentors.Add(obj);
            db.SaveChanges();
        }

        public void Update(Mentor obj)
        {
            db.Mentors.Update(obj);
            db.SaveChanges();
        }

        public void Delete(Mentor obj)
        {
            db.Mentors.Remove(obj);
            db.SaveChanges();
        }

        public Mentor GetById(int id)
        {
            return db.Mentors.First(m => m.Id == id);
        }

        public IEnumerable<Mentor> Get(Expression<Func<Mentor, bool>> filter)
        {
            IQueryable<Mentor> query = db.Mentors;

            query = query.Where(filter);

            return query;
        }
    }
}

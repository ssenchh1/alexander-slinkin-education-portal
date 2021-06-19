using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models.Users;
using EduPortal.Infrastructure.Context;

namespace EduPortal.Infrastructure.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private EducationalPortalContext db;

        public UserRepository(EducationalPortalContext dbcontext)
        {
            db = dbcontext;
        }

        public void Add(User obj)
        {
            db.Users.Add(obj);
            db.SaveChanges();
        }

        public void Update(User obj)
        {
            db.Users.Update(obj);
            db.SaveChanges();
        }

        public void Delete(User obj)
        {
            db.Remove(obj);
            db.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User GetById(int id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> Get(Expression<Func<User, bool>> filter)
        {
            IQueryable<User> query = db.Users;

            query = query.Where(filter);

            return query;
        }
    }
}

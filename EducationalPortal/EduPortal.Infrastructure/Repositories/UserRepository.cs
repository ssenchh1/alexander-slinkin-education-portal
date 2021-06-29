using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models.Users;
using EduPortal.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EduPortal.Infrastructure.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private EducationalPortalContext db;

        public UserRepository(EducationalPortalContext dbcontext)
        {
            db = dbcontext;
        }

        public async Task Add(User obj)
        {
            await db.Users.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task Update(User obj)
        {
            db.Users.Update(obj);
            await db.SaveChangesAsync();
        }

        public async Task Delete(User obj)
        {
            db.Remove(obj);
            await db.SaveChangesAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await db.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public IQueryable<User> Get(Expression<Func<User, bool>> filter)
        {
            IQueryable<User> query = db.Users;

            query = query.Where(filter);

            return query;
        }
    }
}

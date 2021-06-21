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
    public class StudentRepository : IRepository<Student>
    {
        private EducationalPortalContext db;

        public StudentRepository(EducationalPortalContext dbcontext)
        {
            db = dbcontext;
        }

        public async Task Add(Student obj)
        {
            await db.Students.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task Update(Student obj)
        {
            db.Students.Update(obj);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Student obj)
        {
            db.Students.Remove(obj);
            await db.SaveChangesAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await db.Students.FirstAsync(s => s.Id == id);
        }

        public IQueryable<Student> Get(Expression<Func<Student, bool>> filter)
        {
            IQueryable<Student> query = db.Students;

            query = query.Where(filter);

            return query;
        }
    }
}

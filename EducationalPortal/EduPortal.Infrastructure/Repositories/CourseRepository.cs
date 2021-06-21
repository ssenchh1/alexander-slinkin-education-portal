using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models;
using EduPortal.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EduPortal.Infrastructure.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        private EducationalPortalContext db;

        public CourseRepository(EducationalPortalContext dbcontext)
        {
            db = dbcontext;
        }

        public async Task Add(Course obj)
        {
            await db.Courses.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task Update(Course obj)
        {
            db.Courses.Update(obj);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Course obj)
        {
            db.Courses.Remove(obj);
            await db.SaveChangesAsync();
        }

        public async Task<Course> GetById(int id)
        {
            return await db.Courses.FirstOrDefaultAsync(c => c.Id == id);
        }

        public IQueryable<Course> Get(Expression<Func<Course, bool>> filter)
        {
            IQueryable<Course> query = db.Courses;

            query = query.Where(filter);

            return query;
        }
    }
}

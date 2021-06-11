using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models;
using EduPortal.Infrastructure.Context;
using EduPortal.Infrastructure.FileStorage;

namespace EduPortal.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private EducationalPortalContext db;

        public CourseRepository(EducationalPortalContext dbcontext)
        {
            db = dbcontext;
        }

        public void Add(Course obj)
        {
            db.Courses.Add(obj);
            db.SaveChanges();
        }

        public void Update(Course obj)
        {
            db.Courses.Update(obj);
            db.SaveChanges();
        }

        public void Delete(Course obj)
        {
            db.Courses.Remove(obj);
            db.SaveChanges();
        }

        public IEnumerable<Course> GetAll()
        {
            return db.Courses;
        }

        public Course GetById(int id)
        {
            return db.Courses.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Course> Get(Expression<Func<Course, bool>> filter)
        {
            IQueryable<Course> query = db.Courses;

            query = query.Where(filter);

            return query;
        }
    }
}

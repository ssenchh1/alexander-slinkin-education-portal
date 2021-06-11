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
    public class StudentRepository : IRepository<Student>
    {
        private EducationalPortalContext db;

        public StudentRepository(EducationalPortalContext dbcontext)
        {
            db = dbcontext;
        }

        public void Add(Student obj)
        {
            db.Students.Add(obj);
            db.SaveChanges();
        }

        public void Update(Student obj)
        {
            db.Students.Update(obj);
            db.SaveChanges();
        }

        public void Delete(Student obj)
        {
            db.Students.Remove(obj);
            db.SaveChanges();
        }

        public IEnumerable<Student> GetAll()
        {
            return db.Students;
        }

        public Student GetById(int id)
        {
            return db.Students.First(s => s.Id == id);
        }

        public IEnumerable<Student> Get(Expression<Func<Student, bool>> filter)
        {
            IQueryable<Student> query = db.Students;

            query = query.Where(filter);

            return query;
        }
    }
}

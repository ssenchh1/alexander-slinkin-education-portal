using System;
using System.Collections.Generic;
using System.Linq;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models;
using EduPortal.Infrastructure.FileStorage;

namespace EduPortal.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private FileDBManager jsonDb;

        public CourseRepository(FileDBManager dbManager)
        {
            jsonDb = dbManager;
        }

        public void Add(Course obj)
        {
            jsonDb.Write(obj);
        }

        public void Update(Course oldObj, Course newObj)
        {
            jsonDb.Update(oldObj, newObj);
        }

        public void Delete(Course obj)
        {
            jsonDb.Remove(obj);
        }

        public IEnumerable<Course> GetAll()
        {
            return jsonDb.GetAllRecords<Course>();
        }

        public Course GetById(int id)
        {
            return jsonDb.GetAllRecords<Course>().FirstOrDefault(c => c.Id == id);
        }
    }
}

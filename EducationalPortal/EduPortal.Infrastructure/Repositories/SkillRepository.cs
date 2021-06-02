using System;
using System.Collections.Generic;
using System.Linq;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models;
using EduPortal.Infrastructure.FileStorage;

namespace EduPortal.Infrastructure.Repositories
{
    class SkillRepository : ISkillRepository
    {
        private FileDBManager jsonDb;

        public SkillRepository(FileDBManager dbManager)
        {
            jsonDb = dbManager;
        }

        public void Add(Skill obj)
        {
            jsonDb.Write(obj);
        }

        public void Update(Skill oldObj, Skill newObj)
        {
            jsonDb.Update(oldObj, newObj);
        }

        public void Delete(Skill obj)
        {
            jsonDb.Remove(obj);
        }

        public IEnumerable<Skill> GetAll()
        {
            return jsonDb.GetAllRecords<Skill>();
        }

        public Skill GetById(int id)
        {
            return jsonDb.GetAllRecords<Skill>().FirstOrDefault(s => s.Id == id);
        }
    }
}

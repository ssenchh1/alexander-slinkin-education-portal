using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models;
using EduPortal.Infrastructure.Context;
using EduPortal.Infrastructure.FileStorage;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPortal.Infrastructure.Repositories
{
    class SkillRepository : ISkillRepository
    {
        private EducationalPortalContext db;

        public SkillRepository(EducationalPortalContext dbcontext)
        {
            db = dbcontext;
        }

        public void Add(Skill obj)
        {
            db.Skills.Add(obj);
            db.SaveChanges();
        }

        public void Update(Skill obj)
        {
            db.Skills.Update(obj);
            db.SaveChanges();
        }

        public void Delete(Skill obj)
        {
            db.Skills.Remove(obj);
        }

        public IEnumerable<Skill> GetAll()
        {
            return db.Skills;
        }

        public Skill GetById(int id)
        {
            return db.Skills.First(i => i.Id == id);
        }

        public IEnumerable<Skill> Get(Expression<Func<Skill, bool>> filter)
        {
            IQueryable<Skill> query = db.Skills;

            query = query.Where(filter);

            return query;
        }
    }
}

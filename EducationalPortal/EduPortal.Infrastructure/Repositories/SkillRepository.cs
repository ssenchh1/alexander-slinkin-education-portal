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
    class SkillRepository : IRepository<Skill>
    {
        private EducationalPortalContext db;

        public SkillRepository(EducationalPortalContext dbcontext)
        {
            db = dbcontext;
        }

        public async Task Add(Skill obj)
        {
            await db.Skills.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task Update(Skill obj)
        {
            db.Skills.Update(obj);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Skill obj)
        {
            db.Skills.Remove(obj);
            await db.SaveChangesAsync();
        }

        public async Task<Skill> GetById(int id)
        {
            return await  db.Skills.FirstAsync(i => i.Id == id);
        }

        public IQueryable<Skill> Get(Expression<Func<Skill, bool>> filter)
        {
            IQueryable<Skill> query = db.Skills;

            query = query.Where(filter);

            return query;
        }
    }
}

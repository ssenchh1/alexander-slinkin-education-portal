using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models.Materials;
using EduPortal.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EduPortal.Infrastructure.Repositories
{
    public class MaterialRepository : IRepository<Material>
    {
        private EducationalPortalContext db;

        public MaterialRepository(EducationalPortalContext dbcontext)
        {
            db = dbcontext;
        }

        public async Task Add(Material obj)
        {
            await db.Materials.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task Update(Material obj)
        {
            db.Materials.Update(obj);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Material obj)
        {
            db.Materials.Remove(obj);
            await db.SaveChangesAsync();
        }

        public async Task<Material> GetById(int id)
        {
            return await db.Materials.FirstOrDefaultAsync(m => m.Id == id);
        }

        public IQueryable<Material> Get(Expression<Func<Material, bool>> filter)
        {
            IQueryable<Material> query = db.Materials;

            query = query.Where(filter);

            return query;
        }
    }
}

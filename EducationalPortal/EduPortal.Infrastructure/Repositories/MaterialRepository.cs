using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models.Materials;
using EduPortal.Infrastructure.Context;

namespace EduPortal.Infrastructure.Repositories
{
    public class MaterialRepository : IRepository<Material>
    {
        private EducationalPortalContext db;

        public MaterialRepository(EducationalPortalContext dbcontext)
        {
            db = dbcontext;
        }

        public void Add(Material obj)
        {
            db.Materials.Add(obj);
            db.SaveChanges();
        }

        public void Update(Material obj)
        {
            db.Materials.Update(obj);
            db.SaveChanges();
        }

        public void Delete(Material obj)
        {
            db.Materials.Remove(obj);
            db.SaveChanges();
        }

        public IEnumerable<Material> GetAll()
        {
            return db.Materials;
        }

        public Material GetById(int id)
        {
            return db.Materials.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Material> Get(Expression<Func<Material, bool>> filter)
        {
            IQueryable<Material> query = db.Materials;

            query = query.Where(filter);

            return query;
        }
    }
}

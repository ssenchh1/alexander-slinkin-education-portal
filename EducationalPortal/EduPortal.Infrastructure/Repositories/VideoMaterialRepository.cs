using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models.Materials;
using EduPortal.Infrastructure.Context;

namespace EduPortal.Infrastructure.Repositories
{
    public class VideoMaterialRepository : IRepository<VideoMaterial>
    {
        private EducationalPortalContext db;

        public VideoMaterialRepository(EducationalPortalContext context)
        {
            db = context;
        }

        public void Add(VideoMaterial obj)
        {
            db.VideoMaterials.Add(obj);
            db.SaveChanges();
        }

        public void Update(VideoMaterial obj)
        {
            db.VideoMaterials.Update(obj);
            db.SaveChanges();
        }

        public void Delete(VideoMaterial obj)
        {
            db.VideoMaterials.Remove(obj);
            db.SaveChanges();
        }

        public IEnumerable<VideoMaterial> GetAll()
        {
            return db.VideoMaterials;
        }

        public VideoMaterial GetById(int id)
        {
            return db.VideoMaterials.First(v => v.Id == id);
        }

        public IEnumerable<VideoMaterial> Get(Expression<Func<VideoMaterial, bool>> filter)
        {
            IQueryable<VideoMaterial> query = db.VideoMaterials;

            query = query.Where(filter);

            return query;
        }
    }
}

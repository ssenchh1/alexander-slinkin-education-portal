using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models.Materials;
using EduPortal.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EduPortal.Infrastructure.Repositories
{
    public class VideoMaterialRepository : IRepository<VideoMaterial>
    {
        private EducationalPortalContext db;

        public VideoMaterialRepository(EducationalPortalContext context)
        {
            db = context;
        }

        public async Task Add(VideoMaterial obj)
        {
            await db.VideoMaterials.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task Update(VideoMaterial obj)
        {
            db.VideoMaterials.Update(obj);
            await db.SaveChangesAsync();
        }

        public async Task Delete(VideoMaterial obj)
        {
            db.VideoMaterials.Remove(obj);
            await db.SaveChangesAsync();
        }

        public async Task<VideoMaterial> GetById(int id)
        {
            return await db.VideoMaterials.FirstAsync(v => v.Id == id);
        }

        public IQueryable<VideoMaterial> Get(Expression<Func<VideoMaterial, bool>> filter)
        {
            IQueryable<VideoMaterial> query = db.VideoMaterials;

            query = query.Where(filter);

            return query;
        }
    }
}

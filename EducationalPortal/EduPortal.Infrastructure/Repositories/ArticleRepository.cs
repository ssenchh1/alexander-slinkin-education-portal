using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models.Materials;
using EduPortal.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EduPortal.Infrastructure.Repositories
{
    public class ArticleRepository : IRepository<Article>
    {
        private EducationalPortalContext db;

        public ArticleRepository(EducationalPortalContext context)
        {
            db = context;
        }

        public async Task Add(Article obj)
        {
            await db.Articles.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task Update(Article obj)
        {
            db.Articles.Update(obj);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Article obj)
        {
            db.Articles.Remove(obj);
            await db.SaveChangesAsync();
        }

        public async Task<Article> GetById(int id)
        {
            return await db.Articles.FirstAsync(a => a.Id == id);
        }

        public IQueryable<Article> Get(Expression<Func<Article, bool>> filter)
        {
            IQueryable<Article> query = db.Articles;

            query = query.Where(filter);

            return query;
        }
    }
}

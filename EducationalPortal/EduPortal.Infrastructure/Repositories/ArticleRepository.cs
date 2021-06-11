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
    public class ArticleRepository : IArticleRepository
    {
        private EducationalPortalContext db;

        public ArticleRepository(EducationalPortalContext context)
        {
            db = context;
        }

        public void Add(Article obj)
        {
            db.Articles.Add(obj);
            db.SaveChanges();
        }

        public void Update(Article obj)
        {
            db.Articles.Update(obj);
            db.SaveChanges();
        }

        public void Delete(Article obj)
        {
            db.Articles.Remove(obj);
            db.SaveChanges();
        }

        public IEnumerable<Article> GetAll()
        {
            return db.Articles;
        }

        public Article GetById(int id)
        {
            return db.Articles.First(a => a.Id == id);
        }

        public IEnumerable<Article> Get(Expression<Func<Article, bool>> filter)
        {
            IQueryable<Article> query = db.Articles;

            query = query.Where(filter);

            return query;
        }
    }
}

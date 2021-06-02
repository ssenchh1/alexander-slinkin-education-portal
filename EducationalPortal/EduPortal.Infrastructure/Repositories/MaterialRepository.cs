using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models.Materials;
using EduPortal.Infrastructure.FileStorage;

namespace EduPortal.Infrastructure.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private FileDBManager jsonDb;

        public MaterialRepository(FileDBManager dbManager)
        {
            jsonDb = dbManager;
        }

        public void Add(Material obj)
        {
            jsonDb.Write(obj);
        }

        public void Update(Material oldObj, Material newObj)
        {
            jsonDb.Update(oldObj, newObj);
        }

        public void Delete(Material obj)
        {
            jsonDb.Remove(obj);
        }

        public IEnumerable<Material> GetAll()
        {
            return jsonDb.GetAllRecords<Material>();
        }

        public Material GetById(int id)
        {
            return jsonDb.GetAllRecords<Material>().FirstOrDefault(m => m.Id == id);
        }
    }
}

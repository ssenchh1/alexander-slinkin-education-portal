using System;
using System.Collections.Generic;
using System.Linq;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models.Users;
using EduPortal.Infrastructure.FileStorage;

namespace EduPortal.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private FileDBManager jsonDb;

        public UserRepository(FileDBManager dbManager)
        {
            jsonDb = dbManager;
        }

        public void Add(User obj)
        {
            jsonDb.Write(obj);
        }

        public void Update(User oldObj, User newObj)
        {
            jsonDb.Update(oldObj, newObj);
        }

        public void Delete(User obj)
        {
            jsonDb.Remove(obj);
        }

        public IEnumerable<User> GetAll()
        {
            return jsonDb.GetAllRecords<User>();
        }

        public User GetById(int id)
        {
            return jsonDb.GetAllRecords<User>().FirstOrDefault(u => u.Id == id);
        }
    }
}

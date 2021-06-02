using System.Collections.Generic;
using System.IO;
using System.Linq;
using EduPortal.Domain.Models;
using Newtonsoft.Json;

namespace EduPortal.Infrastructure.FileStorage
{
    public class FileDBManager
    {
        private string path;

        public FileDBManager(string path)
        {
            this.path = path;
        }

        public void Write<T>(T obj)
        {
            var records = GetAllRecords<T>();

            if(records == null)
            {
                var newrecords = new List<T>();
                newrecords.Add(obj);
                records = newrecords;
            }
            else
            {
                records.Add(obj);
            }
            
            File.WriteAllText(path, JsonConvert.SerializeObject(records));
        }

        public void Remove<T>(T obj) where T : IEntity
        {
            var records = GetAllRecords<T>();

            records.Remove(records.First(r => r.Id == obj.Id));

            File.WriteAllText(path, JsonConvert.SerializeObject(records));
        }

        public void Update<T>(T oldObj, T newObj) where T : IEntity
        {
            var records = GetAllRecords<T>();

            //if(records == null)
            //{
            //    records.Add(oldObj);
            //}

            //records.Remove(oldObj);
            //records.Add(newObj);

            records[records.IndexOf(records.First(r => r.Id == oldObj.Id))] = newObj;

            File.WriteAllText(path, JsonConvert.SerializeObject(records));
        }

        public List<T> GetAllRecords<T>()
        {
            var json = File.ReadAllText(path);

            var records = JsonConvert.DeserializeObject<List<T>>(json);

            return records;
        }

        public int GetObjectsCount<T>()
        {
            return GetAllRecords<T>().Count;
        }
    }
}
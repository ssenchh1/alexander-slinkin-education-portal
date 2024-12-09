using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Registration
{
    public class DBManager
    {
        private string path;

        public DBManager(string path)
        {
            this.path = path;
        }

        public void Write<T>(T obj)
        {
            var records = GetAllRecords<T>();

            records.Add(obj);

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
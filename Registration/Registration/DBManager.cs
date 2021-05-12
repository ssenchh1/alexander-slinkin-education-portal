using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Registration
{
    public class DBManager
    {
        private IParser parser;
        private IReader reader;
        private IWriter writer;
        private string path = @"C:\Users\ssenchh\Desktop\persons.csv";

        public DBManager(IParser parser)
        {
            this.parser = parser;
        }

        public void Write<T>(T obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(@"C:\Users\ssenchh\Desktop\database.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }

            var str = parser.Parse(obj);

            using (StreamWriter sr = new StreamWriter(path))
            {
                sr.WriteLine(str);
            }
        }

        public List<string> GetAllRecords()
        {
            var content = "";
            using (StreamReader sr = new StreamReader(path))
            {
                content = sr.ReadToEnd();
            }

            return content.Split("\r\n").ToList();
        }

        public int GetObjectsCount()
        {
            return GetAllRecords().Count;
        }
    }
}
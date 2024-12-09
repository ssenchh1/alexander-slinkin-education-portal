using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

namespace Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new DBManager(@"C:\Users\ssenchh\Desktop\database.json");
            var auth = new Autorisator(manager);
            auth.Run();
        }
    }
}

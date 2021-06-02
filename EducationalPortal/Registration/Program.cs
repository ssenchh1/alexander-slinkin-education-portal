using EduPortal.UI.Views.Account;
using EduPortal.Infrastructure.FileStorage;

namespace Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new FileDBManager(@"C:\Users\ssenchh\Desktop\database.json");
            var auth = new Authorization(manager);
            auth.Run();
        }
    }
}

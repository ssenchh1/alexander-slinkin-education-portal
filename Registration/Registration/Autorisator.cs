using System;

namespace Registration
{
    public class Autorisator
    {
        private DBManager db;

        public Autorisator(DBManager dbManager)
        {
            db = dbManager;
        }

        public void Run()
        {
            ChooseAction();
        }

        public void ChooseAction()
        {
            Console.WriteLine("Do you want to sign in or register a new account? 1 or 2");
            var input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1: SignIn();
                    break;
                case 2: Register();
                    break;
                default: ChooseAction();
                    break;
            }
        }

        public void SignIn()
        {
            Console.Write("Your login: ");
            var login = Console.ReadLine();

            Console.Write("Your password: ");
            var password = Console.ReadLine();

            if (db.GetAllRecords().Exists(r => r.Split(",")[0] == login && r.Split(",")[1] == password))
            {
                Console.WriteLine("You are signed in");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public void Register()
        {
            Console.Write("Create your login: ");
            var login = Console.ReadLine();

            Console.Write("Enter your password: ");
            var password = Console.ReadLine();

            Console.Write("Enter your password once again: ");
            var newPassword = Console.ReadLine();

            if (password == newPassword)
            {
                if (!db.GetAllRecords().Exists(r => r.Split(",")[0] == login))
                {
                    db.Write(new User(){Login = login, Password = password});
                    Console.WriteLine("Now you are registered");
                }
                else
                {
                    Console.WriteLine("User with this login already exists. Try again");
                    Register();
                }
            }
        }
    }
}
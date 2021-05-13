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

        private void ChooseAction()
        {
            Console.WriteLine("Do you want to sign in or register a new account? 1 or 2");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1": SignIn();
                    break;
                case "2": Register();
                    break;
                default: ChooseAction();
                    break;
            }
        }

        private void SignIn()
        {
            Console.Write("Your login: ");
            var login = Console.ReadLine();

            Console.Write("Your password: ");
            var password = Console.ReadLine();

            if (db.GetAllRecords<User>().Exists(r => r.Login == login && r.Password == password))
            {
                Console.WriteLine("You are signed in");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }

        private void Register()
        {
            Console.Write("Create your login: ");
            var login = Console.ReadLine();

            Console.Write("Enter your password: ");
            var password = Console.ReadLine();

            Console.Write("Enter your password once again: ");
            var newPassword = Console.ReadLine();

            if (password == newPassword)
            {
                if (!db.GetAllRecords<User>().Exists(r => r.Login == login))
                {
                    db.Write(new User(){Id = db.GetObjectsCount<User>() + 1, Login = login, Password = password});
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
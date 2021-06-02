using System;
using System.Linq;
using EduPortal.Domain.Models.Users;
using EduPortal.Infrastructure.FileStorage;
using EduPortal.Application.Services;
using EduPortal.Infrastructure.Repositories;
using System.Threading;

namespace EduPortal.UI.Views.Account
{
    public class Authorization
    {
        private readonly FileDBManager db;

        public Authorization(FileDBManager dbManager)
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
                case "1":
                    SignIn();
                    break;
                case "2":
                    Register();
                    break;
                default:
                    ChooseAction();
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

                Thread.Sleep(1000);
                Console.Clear();

                var user = db.GetAllRecords<User>().First(u => u.Login == login);

                Redirect(user);
            }
            else
            {
                Console.WriteLine("Something went wrong");
                ChooseAction();
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
                    var user = new User() {Id = db.GetObjectsCount<User>() + 1, Login = login, Password = password};

                    db.Write(user);
                    Console.WriteLine("Now you are registered");

                    Thread.Sleep(1000);
                    Console.Clear();

                    Redirect(user);
                }
                else
                {
                    Console.WriteLine("User with this login already exists. Try again");
                    Register();
                }
            }
        }

        private void Redirect(User user)
        {
            if (user.Role == "Mentor")
            {
                var mentor = db.GetAllRecords<Mentor>().FirstOrDefault(m => m.Id == user.Id);

                RedirectToMentorView(mentor);
            }
            else
            {
                var student = db.GetAllRecords<Student>().FirstOrDefault(s => s.Id == user.Id);

                RedirectToStudentView(student);
            }
        }

        private void RedirectToStudentView(User user)
        {
            var usersDb = new FileDBManager(@"C:\Users\ssenchh\Desktop\database.json");
            var userRepository = new UserRepository(usersDb);

            var courseDb = new FileDBManager(@"C:\Users\ssenchh\Desktop\Courses.json");
            var courseRepository = new CourseRepository(courseDb);

            var studentService = new StudentService((Student)user, userRepository, courseRepository);

            var studentView = new StudentView(studentService);
            studentView.Run();
        }

        private void RedirectToMentorView(User user)
        {
            var usersDb = new FileDBManager(@"C:\Users\ssenchh\Desktop\database.json");
            var userRepository = new UserRepository(usersDb);

            var courseDb = new FileDBManager(@"C:\Users\ssenchh\Desktop\Courses.json");
            var courseRepository = new CourseRepository(courseDb);

            var materialDB = new FileDBManager(@"C:\Users\ssenchh\Desktop\Meterials.json");
            var materialRepository = new MaterialRepository(materialDB);

            var mentorService = new MentorService((Mentor)user ,userRepository, materialRepository, courseRepository);

            var mentorView = new MentorView(mentorService);
            mentorView.Run();
        }
    }
}

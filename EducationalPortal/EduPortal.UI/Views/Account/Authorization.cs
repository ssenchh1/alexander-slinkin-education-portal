using System;
using System.Linq;
using EduPortal.Domain.Models.Users;
using EduPortal.Application.Services;
using EduPortal.Infrastructure.Repositories;
using System.Threading;
using EduPortal.Domain.Interfaces;
using EduPortal.Infrastructure.Context;

namespace EduPortal.UI.Views.Account
{
    public class Authorization
    {
        private readonly EducationalPortalContext db;
        private readonly IUserRepository users;
        private readonly IRepository<Mentor> mentors;
        private readonly IRepository<Student> students;

        public Authorization(EducationalPortalContext dbManager)
        {
            db = dbManager;
            users = new UserRepository(dbManager);
            mentors = new MentorRepository(dbManager);
            students = new StudentRepository(dbManager);
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

            if (users.Get(u => u.Login == login && u.Password == password).Any())
            {
                Console.WriteLine("You are signed in");

                Thread.Sleep(1000);
                Console.Clear();

                var user = users.Get(u => u.Login == login).First();

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
                if (!users.Get(u => u.Login == login).Any())
                {
                    var user = new Student() {Login = login, Password = password, Role = "Student"};
                    
                    students.Add(user);

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
                var mentor = mentors.Get(m => m.Login == user.Login).First();

                RedirectToMentorView(mentor);
            }
            else
            {
                var student = students.Get(u => u.Login == user.Login).First();

                RedirectToStudentView(student);
            }
        }

        private void RedirectToStudentView(User user)
        {
            var userRepository = new UserRepository(db);
            
            var courseRepository = new CourseRepository(db);

            var studentService = new StudentService((Student)user, userRepository, courseRepository);

            var studentView = new StudentView(studentService);
            studentView.Run();
        }

        private void RedirectToMentorView(User user)
        {
            var userRepository = new UserRepository(db);
            
            var courseRepository = new CourseRepository(db);
            
            var materialRepository = new MaterialRepository(db);

            var articleRepository = new ArticleRepository(db);

            var digitalBookRepository = new DigitalBookRepository(db);

            var videoMaterialRepository = new VideoMaterialRepository(db);

            var mentorService = new MentorService((Mentor)user ,userRepository, materialRepository, courseRepository, 
                                                    articleRepository, digitalBookRepository, videoMaterialRepository);

            var mentorView = new MentorView(mentorService);
            mentorView.Run();
        }
    }
}

using System;
using System.Linq;
using EduPortal.Application.Interfaces;

namespace EduPortal.UI.Views.Account
{
    public class StudentView
    {
        private readonly IStudentService _studentService;

        public StudentView(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public void Run()
        {
            ChooseAction();
        }

        private void ChooseAction()
        {
            Console.WriteLine("What do you want to do? 1 - Get courses catalog, 2 - Get your courses, 3 - Open your profile");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    GetCoursesCatalog();
                    break;
                case "2":
                    GetUserCourses();
                    break;
                case "3":
                    OpenProfile();
                    break;
                default:
                    ChooseAction();
                    break;
            }
        }

        private void GetCoursesCatalog()
        {
            var coursesVM = _studentService.GetAllCourses();

            Console.WriteLine("Course Id\tCourse Name\tPrice");
            foreach (var course in coursesVM?.Courses)
            {
                Console.WriteLine($"{course.Id}\t\t{course.Name}\t\t{course.Price}");
            }

            Console.WriteLine();

            Console.WriteLine("If you want to get a course just enter 1, " +
                "if you want to go back enter 2");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    EnrollCourse();
                    break;
                case "2":
                    ChooseAction();
                    break;
                case "3":
                    ChooseAction();
                    break;
            }

            ChooseAction();
        }

        private void EnrollCourse()
        {
            Console.WriteLine("Enter Id of a course");
            var id = int.Parse(Console.ReadLine());

            _studentService.EnrollCourse(id);
        }

        private void GetUserCourses()
        {
            var coursesVM = _studentService.GetStudentCourses();

            Console.WriteLine("Course Id\tCourse Name\tPrice");
            foreach (var course in coursesVM.Courses)
            {
                Console.WriteLine($"{course.Id}\t{course.Name}\t{course.Price}");
            }

            Console.Write("If You want to open course enter 1, else enter 2");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    OpenCourse();
                    break;
                case "2":
                    ChooseAction();
                    break;
                default:
                    ChooseAction();
                    break;
            }
        }

        private void OpenCourse()
        {
            Console.Write("Enter Id of course: ");
            var id = int.Parse(Console.ReadLine());

            var course = _studentService.GetStudentCourses().Courses.First(c => c.Id == id);

            foreach(var material in course.Materials)
            {
                Console.WriteLine($"{material.Name}");
            }
        }

        private void OpenProfile()
        {
            var profile = _studentService.GetProfile();

            Console.WriteLine();
            foreach (var profileField in profile.Fields)
            {
                Console.WriteLine(profileField.Key + "\t" + profileField.Value);
            }

            Console.WriteLine();

            ChooseAction();
        }
    }
}

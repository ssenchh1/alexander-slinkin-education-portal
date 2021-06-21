using System;
using EduPortal.Application.Interfaces;
using EduPortal.Domain.Models;
using EduPortal.Domain.Models.Materials;

namespace EduPortal.UI.Views.Account
{
    public class MentorView
    {
        private readonly IMentorService _mentorService;

        public MentorView(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }

        public void Run()
        {
            ChooseAction();
        }

        private void ChooseAction()
        {
            Console.WriteLine("What do you want to do? 1 - Create material, 2 - create courses,\n" +
                              "3 - Get your courses, 4 - Get your materials\n" +
                              "5 - Get your profile");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateMaterial();
                    break;
                case "2":
                    CreateCourse();
                    break;
                case "3":
                    GetMentorCourses();
                    break;
                case "4":
                    GetMentorMaterials();
                    break;
                case "5":
                    GetProfile();
                    break;
                default:
                    ChooseAction();
                    break;
            }
        }

        private void GetProfile()
        {
            var profile = _mentorService.GetProfile();

            foreach (var profileField in profile.Fields)
            {
                Console.WriteLine($"{profileField.Key}: {profileField.Value}");
            }

            ChooseAction();
        }

        private void GetMentorMaterials()
        {
            var materials = _mentorService.GetMentor().CreatedMaterials;

            Console.WriteLine("Id\tName\tAuthor");
            foreach (var material in materials)
            {
                Console.WriteLine($"{material.Id}\t{material.Name}\t{material.Author}");
            }

            ChooseAction();
        }

        private void GetMentorCourses()
        {
            var courses = _mentorService.GetMentor().CreatedCourses;

            Console.WriteLine("Id\tName\tDescription");
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Id}\t{course.Name}\t{course.Description}");
            }

            ChooseAction();
        }

        private void CreateCourse()
        {
            Console.Write("Enter course name: ");
            var name = Console.ReadLine();

            Console.Write("Enter course description: ");
            var description = Console.ReadLine();

            Console.Write("Enter course price: ");
            var price = 0m;
            decimal.TryParse(Console.ReadLine(), out price);

            var course = new Course()
            {
                Name = name,
                Description = description,
                Price = price
            };

            _mentorService.CreateCourse(course);

            ChooseAction();
        }

        private void CreateMaterial()
        {
            Console.WriteLine("You wanna create 1- Article, 2 - Digital Book or 3 - Video?");
            var input = Console.ReadLine();

            var material = CreateBaseMaterial();

            switch (input)
            {
                case "1":
                    material = CreateArticle(material);
                    break;
                case "2":
                    material = CreateDigtalBook(material);
                    break;
                case "3":
                    material = CreateVideo(material);
                    break;
                default:
                    return;
            }

            _mentorService.CreateMaterial(material);

            ChooseAction();
        }

        private Material CreateBaseMaterial()
        {
            Console.Write("Enter name: ");
            var name = Console.ReadLine();

            var material = new Material()
            {
                Name = name,
                Author = _mentorService.GetMentor().Login
            };

            return material;
        }

        private Material CreateVideo(Material material)
        {
            Console.Write("Enter length in minutes: ");
            var length = 0;            
            int.TryParse(Console.ReadLine(), out length);

            Console.Write("Enter quality (144, 720, 1080, 2160): ");
            var quality = Quality.Low;
            Quality.TryParse(Console.ReadLine(), out quality);

            var video = new VideoMaterial()
            {
                Category = "Video",
                Name = material.Name,
                Author = material.Author,
                Quality = quality,
                Length = length
            };

            return video;
        }

        private Material CreateDigtalBook(Material material)
        {
            Console.Write("Enter number of pages: ");
            var numberOfPages = 0;
            int.TryParse(Console.ReadLine(), out numberOfPages);

            Console.Write("Enter format: ");
            var format = Console.ReadLine();

            Console.Write("Enter year: ");
            var year = 0;
            int.TryParse(Console.ReadLine(), out year);

            var book = new DigitalBook()
            {
                Category = "DigitalBook",
                Name = material.Name,
                Author = material.Author,
                NumberOfPages = numberOfPages,
                Format = format,
                Year = year
            };

            return book;
        }

        private Material CreateArticle(Material material)
        {
            Console.Write("Enter source: ");
            var source = Console.ReadLine();

            Console.Write("Enter date: ");
            var date = DateTime.MinValue;
            DateTime.TryParse(Console.ReadLine(), out date);

            var article = new Article()
            {
                Category = "Article",
                Name = material.Name,
                Author = material.Author,
                Source = source,
                Date = date
            };

            return article;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduPortal.Application.Interfaces;
using EduPortal.Application.ViewModels;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models;
using EduPortal.Domain.Models.Materials;

namespace EduPortal.Application.Services
{
    public class MentorService : IMentorService
    {
        private readonly IRepository<Material> _materialRepository;
        private readonly IRepository<Course> _courseRepository;

        public MentorService(IRepository<Material> materialRepository, IRepository<Course> courseRepository)
        {
            _materialRepository = materialRepository;
            _courseRepository = courseRepository;
        }

        public Task<IEnumerable<CourseViewModel>> GetUserCourses(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseViewModel>> GetFinishedCourses(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserProfileViewModel> GetProfile(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task CreateArticleAsync(CreateArticleViewModel model, string authorId)
        {
            var article = new Article()
            {
                Name = model.Name, Text = model.Text, Source = model.Source, ProvidedSkills = model.ProvidedSkills,
                Category = model.Category, Date = model.Date, AuthorId = authorId
            };

            await _materialRepository.AddAsync(article);
        }

        public async Task CreateBookAsync(CreateBookViewModel model, string authorId)
        {
            var book = new DigitalBook()
            {
                Name = model.Name, Format = model.Format, Text  = model.Text, NumberOfPages = model.NumberOfPages, Year = model.Year,
                Category = model.Category, ProvidedSkills = model.ProvidedSkills, AuthorId = authorId
            };

            await _materialRepository.AddAsync(book);
        }

        public async Task CreateVideoAsync(CreateVideoViewModel model, string authorId)
        {
            var video = new VideoMaterial()
            {
                Name = model.Name, Category = model.Category, Length = model.Length, ProvidedSkills = model.ProvidedSkills, AuthorId = authorId
            };

            await _materialRepository.AddAsync(video);
        }

        public async Task CreateCourseAsync(CreateCourseViewModel model, string authorId)
        {
            var course = new Course()
                {Name = model.Name, Description = model.Description, Materials = model.Materials, AuthorId = authorId};

            await _courseRepository.AddAsync(course);
        }

        public Task UpdateCourseAsync(CreateCourseViewModel model, string authorId)
        {
            throw new NotImplementedException();
        }
    }
}

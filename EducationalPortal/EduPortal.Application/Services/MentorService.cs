using System;
using System.Collections.Generic;
using EduPortal.Application.Interfaces;
using EduPortal.Application.ViewModels;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models;
using EduPortal.Domain.Models.Materials;
using EduPortal.Domain.Models.Users;

namespace EduPortal.Application.Services
{
    public class MentorService : IMentorService
    {
        private Mentor mentor;

        private readonly IRepository<Article> _articleRepositiry;
        private readonly IRepository<DigitalBook> _digitalBookRepository;
        private readonly IRepository<VideoMaterial> _videoMaterialRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _mentorRepository;

        public MentorService(Mentor mentor, IUserRepository userRepository, IMaterialRepository materialRepository, ICourseRepository courseRepository,
            IRepository<Article> articleRepositiry, IRepository<DigitalBook> digitalBookRepository, IRepository<VideoMaterial> videoMaterialRepository)
        {
            this.mentor = mentor;
            _mentorRepository = userRepository;
            _courseRepository = courseRepository;
            _materialRepository = materialRepository;
            _videoMaterialRepository = videoMaterialRepository;
            _digitalBookRepository = digitalBookRepository;
            _articleRepositiry = articleRepositiry;
        }

        public void CreateCourse(Course course)
        {
            //todo
            //var course = new Course();

            _courseRepository.Add(course);

            if (mentor.CreatedCourses == null)
            {
                mentor.CreatedCourses = new List<Course>();
            }
            mentor.CreatedCourses.Add(course);

            _mentorRepository.Update(mentor);
        }

        public void CreateMaterial(Material material)
        {
            //_materialRepository.Add(material);

            if (material is Article article)
            {
                _articleRepositiry.Add(article);
            }
            else if(material is DigitalBook dBook)
            {
                _digitalBookRepository.Add(dBook);
            }
            else if(material is VideoMaterial vMaterial)
            {
                _videoMaterialRepository.Add(vMaterial);
            }

            if(mentor.CreatedMaterials == null)
            {
                mentor.CreatedMaterials = new List<Material>();
            }

            mentor.CreatedMaterials.Add(material);

            _mentorRepository.Update(mentor);
        }

        public CourseViewModel GetAllCourses()
        {
            //todo
            var courses = new CourseViewModel()
            {
                Courses = _courseRepository.GetAll()
            };

            return courses;
        }

        public UserProfileViewModel GetProfile()
        {
            var properties = mentor.GetType().GetProperties();
            Dictionary<string, object> props = new Dictionary<string, object>();

            foreach (var propertyInfo in properties)
            {
                props.Add(propertyInfo.Name, propertyInfo.GetValue(mentor));
            }

            var profile = new UserProfileViewModel()
            {
                Fields = props
            };

            return profile;
        }

        public Mentor GetMentor()
        {
            if (mentor.CreatedCourses == null)
            {
                mentor.CreatedCourses = new List<Course>();
            }

            if (mentor.CreatedMaterials == null)
            {
                mentor.CreatedMaterials = new List<Material>();
            }

            return mentor;
        }
    }
}

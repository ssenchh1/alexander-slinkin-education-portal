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

        private readonly IMaterialRepository _materialRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _mentorRepository;

        public MentorService(Mentor mentor, IUserRepository userRepository, IMaterialRepository materialRepository, ICourseRepository courseRepository)
        {
            this.mentor = mentor;
            _mentorRepository = userRepository;
            _courseRepository = courseRepository;
            _materialRepository = materialRepository;
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

            _mentorRepository.Update(_mentorRepository.GetById(mentor.Id), mentor);
        }

        public void CreateMaterial(Material material)
        {
            _materialRepository.Add(material);

            if(mentor.CreatedMaterials == null)
            {
                mentor.CreatedMaterials = new List<Material>();
            }
            mentor.CreatedMaterials.Add(material);

            _mentorRepository.Update(_mentorRepository.GetById(mentor.Id), mentor);
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
            return mentor;
        }
    }
}

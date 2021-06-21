using System;
using System.Collections.Generic;
using EduPortal.Application.Interfaces;
using EduPortal.Application.ViewModels;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models;
using EduPortal.Domain.Models.Users;

namespace EduPortal.Application.Services
{
    public class StudentService : IStudentService
    {
        private Student student;

        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<User> _studentRepository;

        public StudentService(Student student, IRepository<User> userRepository, IRepository<Course> courseRepository)
        {
            this.student = student;
            _courseRepository = courseRepository;
            _studentRepository = userRepository;
        }

        public CourseViewModel GetAllCourses()
        {
            //todo
            var courses = new CourseViewModel()
            {
                Courses = _courseRepository.Get(c => true)
            };

            return courses;
        }

        public UserProfileViewModel GetProfile()
        {
            var properties = student.GetType().GetProperties();
            Dictionary<string, object> props = new Dictionary<string, object>();

            foreach (var propertyInfo in properties)
            {
                props.Add(propertyInfo.Name, propertyInfo.GetValue(student));
            }

            var profile = new UserProfileViewModel()
            {
                Fields = props
            };

            return profile;
        }

        public void EnrollCourse(int courseId)
        {
            var course = _courseRepository.GetById(courseId);

            if(student.Courses == null)
            {
                student.Courses = new List<Course>();
            }
            student.Courses.Add(course);

            _studentRepository.Update(student);
        }

        public CourseViewModel GetStudentCourses()
        {
            var courses = new CourseViewModel()
            {
                Courses = new List<Course>()
            };

            courses.Courses = student.Courses ?? courses.Courses;

            return courses;
        }

        public CourseViewModel GetAvailableCourses()
        {
            throw new NotImplementedException();
        }

        public CourseViewModel GetFinishedCourses()
        {
            throw new NotImplementedException();
        }
    }
}

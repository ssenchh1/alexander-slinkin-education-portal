using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<CoursesViewModel> GetAllCourses()
        {
            //todo
            var courses = new CoursesViewModel()
            {
                //Courses = await _courseRepository.Get()
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
                //Fields = props
            };

            return profile;
        }

        public async void EnrollCourse(int courseId)
        {
            var course = await _courseRepository.GetByIdAsync(courseId);

            if(student.Courses == null)
            {
                student.Courses = new List<Course>();
            }
            
            student.Courses.Add(course);

            await _studentRepository.UpdateAsync(student);
        }

        public CoursesViewModel GetStudentCourses()
        {
            var courses = new CoursesViewModel()
            {
                Courses = new List<Course>()
            };

            courses.Courses = student.Courses ?? courses.Courses;

            return courses;
        }

        public CoursesViewModel GetAvailableCourses()
        {
            throw new NotImplementedException();
        }

        public CoursesViewModel GetFinishedCourses()
        {
            throw new NotImplementedException();
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
    }
}

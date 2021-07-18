using System.Linq;
using System.Threading.Tasks;
using EduPortal.Application.Interfaces;
using EduPortal.Application.ViewModels;
using EduPortal.Domain;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models;
using EduPortal.Domain.Models.Users;

namespace EduPortal.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;

        public CourseService(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CoursesViewModel> GetCourses()
        {
            return new CoursesViewModel()
            {
                Courses = await _courseRepository.GetAsync()
            };
        }

        public async Task<PagedList<Course>> GetCoursesPaged(int pageNumber, int pageSize)
        {
            return await _courseRepository.GetPagedAsync(pageNumber, pageSize, null, "Author,Students");
        }

        public async Task<CoursesViewModel> GetTopCourses()
        {
            return new CoursesViewModel()
            {
                Courses = await _courseRepository.GetAsync(null, "Students", c => c.OrderBy(c => c.Students.Count), 0, 5)
            };
        }

        public async Task<CourseViewModel> GetCourseVMById(int id, string include)
        {
            var course = await _courseRepository.GetByIdAsync(id, include);
            var courseVM = new CourseViewModel()
            {
                Id = course.Id, Title = course.Name, Author = course.AuthorId, Description = course.Description,
                StudentsCount = course.Students.Count
            };

            return courseVM;
        }

        public async Task<Course> GetCourseById(int id, string include)
        {
            return await _courseRepository.GetByIdAsync(id, include);
        }

        public async Task AddStudentToCourse(int courseId, User student)
        {
            var course = await _courseRepository.GetByIdAsync(courseId, "Students");
            course.Students.Add(new Student(){Email = student.Email, Login = student.Login, Password = student.Password, UserName = student.UserName, Role = student.Role});
            await _courseRepository.UpdateAsync(course);
        }
    }
}

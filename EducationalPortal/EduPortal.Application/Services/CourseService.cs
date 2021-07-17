using System.Linq;
using System.Threading.Tasks;
using EduPortal.Application.Interfaces;
using EduPortal.Application.ViewModels;
using EduPortal.Domain;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models;

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
            return await _courseRepository.GetPagedAsync(pageNumber, pageSize);
        }

        public async Task<CoursesViewModel> GetTopCourses()
        {
            return new CoursesViewModel()
            {
                Courses = await _courseRepository.GetAsync(null, "Students", c => c.OrderBy(c => c.Students.Count), 0, 5)
            };
        }
    }
}

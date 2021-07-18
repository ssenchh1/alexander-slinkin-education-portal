using System.Threading.Tasks;
using EduPortal.Application.ViewModels;
using EduPortal.Domain;
using EduPortal.Domain.Models;
using EduPortal.Domain.Models.Users;

namespace EduPortal.Application.Interfaces
{
    public interface ICourseService
    {
        Task<CoursesViewModel> GetCourses();

        Task<PagedList<Course>> GetCoursesPaged(int pageNumber, int pageSize);

        Task<CoursesViewModel> GetTopCourses();

        Task<CourseViewModel> GetCourseVMById(int id, string include);

        Task<Course> GetCourseById(int id, string include);

        Task AddStudentToCourse(int courseId, User student);
    }
}

using System.Threading.Tasks;
using EduPortal.Application.ViewModels;
using EduPortal.Domain;
using EduPortal.Domain.Models;

namespace EduPortal.Application.Interfaces
{
    public interface ICourseService
    {
        Task<CoursesViewModel> GetCourses();

        Task<PagedList<Course>> GetCoursesPaged(int pageNumber, int pageSize);

        Task<CoursesViewModel> GetTopCourses();
    }
}

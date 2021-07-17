using EduPortal.Application.ViewModels;

namespace EduPortal.Application.Interfaces
{
    public interface IStudentService : IUserService
    {
        void EnrollCourse(int courseId);

        CoursesViewModel GetStudentCourses();

        CoursesViewModel GetAvailableCourses();

        CoursesViewModel GetFinishedCourses();
    }
}

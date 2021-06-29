using EduPortal.Application.ViewModels;

namespace EduPortal.Application.Interfaces
{
    public interface IUserService
    {
        CourseViewModel GetAllCourses();

        UserProfileViewModel GetProfile();
    }
}

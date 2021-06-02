using System;
using EduPortal.Application.ViewModels;

namespace EduPortal.Application.Interfaces
{
    public interface IStudentService : IUserService
    {
        void EnrollCourse(int courseId);

        CourseViewModel GetStudentCourses();

        CourseViewModel GetAvailableCourses();

        CourseViewModel GetFinishedCourses();
    }
}

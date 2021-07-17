using System.Collections.Generic;
using EduPortal.Domain.Models.Joining;

namespace EduPortal.Domain.Models.Users
{
    public class Student : User
    {
        public List<Course> Courses { get; set; }

        public List<Course> FinishedCourses { get; set; }

        public List<StudentCourse> StudentCourses { get; set; }
        public List<StudentFinishedCourse> StudentFinishedCourses { get; set; }
    }
}

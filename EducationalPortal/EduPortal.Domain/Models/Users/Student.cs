using System.Collections.Generic;

namespace EduPortal.Domain.Models.Users
{
    public class Student : User
    {
        public List<Course> Courses { get; set; }

        public List<Course> FinishedCourses { get; set; }
    }
}

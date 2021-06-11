using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPortal.Domain.Models.Users
{
    [Table("Students")]
    public class Student : User
    {
        public List<Course> Courses { get; set; }

        public List<Course> FinishedCourses { get; set; }
    }
}

using System.Collections.Generic;
using EduPortal.Domain.Models;

namespace EduPortal.Application.ViewModels
{
    public class CourseViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
    }
}

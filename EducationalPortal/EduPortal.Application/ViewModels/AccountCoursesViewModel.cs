using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduPortal.Domain.Models;

namespace EduPortal.Application.ViewModels
{
    public class AccountCoursesViewModel
    {
        public IEnumerable<Course> Courses { get; set; }

        public IEnumerable<Course> FinishedCourses { get; set; }
    }
}

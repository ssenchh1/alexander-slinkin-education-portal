
using System.Collections.Generic;
using EduPortal.Domain.Models.Materials;

namespace EduPortal.Domain.Models.Users
{
    public class Mentor : User
    {
        public decimal Salary { get; set; }

        public List<Material> CreatedMaterials { get; set; }

        public List<Course> CreatedCourses { get; set; }
    }
}

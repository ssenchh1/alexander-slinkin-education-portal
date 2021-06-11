using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EduPortal.Domain.Models.Materials;

namespace EduPortal.Domain.Models.Users
{
    [Table("Mentors")]
    public class Mentor : User
    {
        public decimal Salary { get; set; }

        public List<Material> CreatedMaterials { get; set; }

        public List<Course> CreatedCourses { get; set; }
    }
}

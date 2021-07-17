using System.Collections.Generic;
using EduPortal.Domain.Models.Materials;

namespace EduPortal.Application.ViewModels
{
    public class CreateCourseViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<Material> Materials { get; set; }
    }
}

using System;
using System.Collections.Generic;
using EduPortal.Domain.Models.Materials;

namespace EduPortal.Domain.Models
{
    public class Course : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public int Duration { get; set; }

        public List<Material> Materials { get; set; }
    }
}

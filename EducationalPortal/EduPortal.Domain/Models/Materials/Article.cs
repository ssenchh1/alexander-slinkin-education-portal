using System;

namespace EduPortal.Domain.Models.Materials
{
    public class Article : Material
    {
        public DateTime Date { get; set; }

        public string Source { get; set; }
    }
}

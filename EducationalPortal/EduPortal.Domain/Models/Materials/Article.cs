using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPortal.Domain.Models.Materials
{
    [Table("Articles")]
    public class Article : Material
    {
        public DateTime Date { get; set; }

        public string Source { get; set; }
    }
}

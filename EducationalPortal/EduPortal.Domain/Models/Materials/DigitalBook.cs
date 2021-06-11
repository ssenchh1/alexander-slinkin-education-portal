using System.ComponentModel.DataAnnotations.Schema;

namespace EduPortal.Domain.Models.Materials
{
    [Table("DigitalBooks")]
    public class DigitalBook : Material
    {
        public int NumberOfPages { get; set; }

        public string Format { get; set; }

        public int Year { get; set; }
    }
}

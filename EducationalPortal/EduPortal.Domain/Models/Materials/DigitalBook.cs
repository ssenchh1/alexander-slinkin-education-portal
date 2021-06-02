
namespace EduPortal.Domain.Models.Materials
{
    public class DigitalBook : Material
    {
        public int NumberOfPages { get; set; }

        public string Format { get; set; }

        public int Year { get; set; }
    }
}

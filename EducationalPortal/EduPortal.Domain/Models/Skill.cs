
namespace EduPortal.Domain.Models
{
    public class Skill : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }
    }
}

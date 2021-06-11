using System.Collections.Generic;

namespace EduPortal.Domain.Models.Materials
{
    public class Material : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public List<Skill> ProvidedSkills { get; set; }
    }
}

using System.Collections.Generic;

namespace EduPortal.Domain.Models.Users
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public List<Skill> Skills { get; set; }

        public string Role { get; set; }
    }
}

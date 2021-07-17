using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace EduPortal.Domain.Models.Users
{
    public class User : IdentityUser
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public virtual List<Skill> Skills { get; set; }

        public string Role { get; set; }
    }
}

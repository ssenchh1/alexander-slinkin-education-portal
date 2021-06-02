using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduPortal.Domain.Models.Users;

namespace EduPortal.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
    }
}

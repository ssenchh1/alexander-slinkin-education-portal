using System;
using EduPortal.Domain.Models;
using EduPortal.Domain.Models.Materials;
using EduPortal.Domain.Models.Users;

namespace EduPortal.Application.Interfaces
{
    public interface IMentorService : IUserService
    {
        void CreateCourse(Course course);

        void CreateMaterial(Material material);

        Mentor GetMentor();
    }
}

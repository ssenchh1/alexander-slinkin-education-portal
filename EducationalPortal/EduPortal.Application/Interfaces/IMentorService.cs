using System;
using EduPortal.Domain.Models;
using EduPortal.Domain.Models.Materials;
using EduPortal.Domain.Models.Users;

namespace EduPortal.Application.Interfaces
{
    public interface IMentorService : IUserService
    {
        public void CreateCourse(Course course);

        public void CreateMaterial(Material material);

        public Mentor GetMentor();
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduPortal.Application.Interfaces;
using EduPortal.Application.ViewModels;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace EduPortal.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IRepository<User> _userRepository;

        public UserService(UserManager<User> userManager, IRepository<User> userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<CourseViewModel>> GetUserCourses(string userId)
        {
            throw new Exception();
            var role = _userRepository.GetAsync(u => u.Id == userId);
        }

        public Task<IEnumerable<CourseViewModel>> GetFinishedCourses(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserProfileViewModel> GetProfile(string userId)
        {
            throw new NotImplementedException();
        }
    }
}

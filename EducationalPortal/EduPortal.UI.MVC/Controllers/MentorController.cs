using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EduPortal.Application.Interfaces;
using EduPortal.Application.ViewModels;
using EduPortal.Domain.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace EduPortal.UI.MVC.Controllers
{
    [Authorize(Roles = "Mentor")]
    public class MentorController : Controller
    {
        private readonly IMentorService _mentorService;
        private readonly UserManager<User> _userManager;

        public MentorController(IMentorService mentorService, UserManager<User> userManager)
        {
            _mentorService = mentorService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(CreateArticleViewModel model)
        {
            var userId = (await _userManager.FindByNameAsync(User.Identity.Name)).Id;
            await _mentorService.CreateArticleAsync(model, userId);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookViewModel model)
        {
            var userId = (await _userManager.FindByNameAsync(User.Identity.Name)).Id;
            await _mentorService.CreateBookAsync(model, userId);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CreateVideo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo(CreateVideoViewModel model)
        {
            var userId = (await _userManager.FindByNameAsync(User.Identity.Name)).Id;
            await _mentorService.CreateVideoAsync(model, userId);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseViewModel model)
        {
            var userId = (await _userManager.FindByNameAsync(User.Identity.Name)).Id;
            await _mentorService.CreateCourseAsync(model, userId);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> UpdateCourse()
        {

        }
    }
}

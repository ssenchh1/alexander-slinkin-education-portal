using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EduPortal.Application.Interfaces;
using EduPortal.Application.ViewModels;
using EduPortal.Domain.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Text) || string.IsNullOrEmpty(model.Source))
            {
                ModelState.AddModelError("Error", "Все поля должны быть заполнены");
            }

            if (ModelState.IsValid)
            {
                var userId = (await _userManager.FindByNameAsync(User.Identity.Name)).Id;
                await _mentorService.CreateArticleAsync(model, userId);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in ModelState["Error"].Errors)
                {
                    ModelState.AddModelError("", "что-то не так");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookViewModel model)
        {
            foreach (var propertyInfo in model.GetType().GetProperties())
            {
                if (string.IsNullOrEmpty(propertyInfo.GetValue(model).ToString()))
                {
                    ModelState.AddModelError("", "Все поля должны быть заполнены");
                }
            }

            if (ModelState.IsValid)
            {
                var userId = (await _userManager.FindByNameAsync(User.Identity.Name)).Id;
                await _mentorService.CreateBookAsync(model, userId);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateVideo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo(CreateVideoViewModel model)
        {
            foreach (var propertyInfo in model.GetType().GetProperties())
            {
                if (string.IsNullOrEmpty(propertyInfo.GetValue(model).ToString()))
                {
                    ModelState.AddModelError("", "Все поля должны быть заполнены");
                }
            }

            if (ModelState.IsValid)
            {
                var userId = (await _userManager.FindByNameAsync(User.Identity.Name)).Id;
                await _mentorService.CreateVideoAsync(model, userId);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCourse()
        {
            var materials = await _mentorService.GetMaterialsAsync();
            ViewBag.Materials = new List<SelectListItem>();
            foreach (var material in materials)
            {
                ViewBag.Materials.Add(new SelectListItem(){Text = material.Name, Value = material.Id.ToString()});
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Description) ||
                model.MaterialIds == null)
            {
                ModelState.AddModelError("", "Все поля должны быть заполнены");
            }

            if (ModelState.IsValid)
            {
                var userId = (await _userManager.FindByNameAsync(User.Identity.Name)).Id;
                model.Materials = await _mentorService.GetMaterialsByIdAsync(model.MaterialIds.Select(s => int.Parse(s)));
                await _mentorService.CreateCourseAsync(model, userId);

                return RedirectToAction("Index", "Home");
            }
            

            var materials = await _mentorService.GetMaterialsAsync();
            ViewBag.Materials = new List<SelectListItem>();
            foreach (var material in materials)
            {
                ViewBag.Materials.Add(new SelectListItem() { Text = material.Name, Value = material.Id.ToString() });
            }

            return View(model);
        }

        //public async Task<IActionResult> UpdateCourse()
        //{

        //}
    }
}

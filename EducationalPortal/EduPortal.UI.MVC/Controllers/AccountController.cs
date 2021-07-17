using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using EduPortal.Application.Interfaces;
using EduPortal.Application.ViewModels;
using EduPortal.Domain.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EduPortal.UI.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IRoleService _roleService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IRoleService roleService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (model.Password != model.PasswordConfirm)
            {
                ModelState.AddModelError("", "Пароли должны совпадать");
            }

            if (!new EmailAddressAttribute().IsValid(model.Email))
            {
                ModelState.AddModelError("", "Неверный адрес электронной почты");
            }

            if (ModelState.IsValid)
            {
                var user = new User() {Email = model.Email, Password = model.Password, UserName = model.Email, Login = model.Login, Role = "Student"};

                var result = await _userManager.CreateAsync(user, user.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, model.RememberMe);
                    await _roleService.SetUserRoleAsync(user, "Student");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var identityError in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, identityError.Description);
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("", "Все поля должны быть заполнены");
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("","Неправильные данные");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ChangeRole(string id, string oldRole, string newRole)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _roleService.SetUserRoleAsync(user, newRole);
            await _roleService.UnsetUserRoleAsync(user, oldRole);
            await _signInManager.RefreshSignInAsync(user);
            return RedirectToAction("Index", "Home");
        }
    }
}

using System.Threading.Tasks;
using EduPortal.Application.Interfaces;
using EduPortal.Domain.Interfaces;
using EduPortal.Domain.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EduPortal.UI.MVC.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository<User> _studentRepository;

        public CoursesController(ICourseService courseService, IUserRepository<User> studentRepository, UserManager<User> userManager)
        {
            _courseService = courseService;
            _studentRepository = studentRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Catalog(int? page)
        {
            int currentPage = page ?? 1;
            int pageSize = 3;

            var courses = await _courseService.GetCoursesPaged(currentPage, pageSize);

            return View(courses);
        }

        public async Task<IActionResult> Course(int? id)
        {
            if (id == null)
            {
                RedirectToAction("Catalog", "Courses");
            }

            var course = await _courseService.GetCourseVMById((int)id, "Students");
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> PurchaseCourse(int id)
        {
            var course = await _courseService.GetCourseById(id, "Students");
            var student = await _studentRepository.GetByIdAsync((await _userManager.FindByNameAsync(User.Identity.Name)).Id);
            await _courseService.AddStudentToCourse(id, student);
            //student.Courses.Add(await _courseService.GetCourseById(id,""));
            return RedirectToAction("Catalog", "Courses");
        }
    }
}

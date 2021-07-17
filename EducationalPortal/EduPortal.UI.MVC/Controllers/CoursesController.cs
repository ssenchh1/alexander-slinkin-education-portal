using System.Linq;
using System.Threading.Tasks;
using EduPortal.Application.Interfaces;
using EduPortal.Application.ViewModels;
using EduPortal.Domain;
using EduPortal.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EduPortal.UI.MVC.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> Catalog(int? page)
        {
            int currentPage = page ?? 1;
            int pageSize = 3;

            var courses = await _courseService.GetCoursesPaged(currentPage, pageSize);

            return View(courses);
        }
    }
}

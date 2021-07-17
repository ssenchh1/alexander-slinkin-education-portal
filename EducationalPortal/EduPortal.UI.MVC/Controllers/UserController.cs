using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace EduPortal.UI.MVC.Controllers
{
    public class UserController : Controller
    {
        [Authorize]
        public IActionResult MyProfile()
        {
            return View();
        }
    }
}

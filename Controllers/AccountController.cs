using HospitalManagment.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagment.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(users model)
        {
            if (ModelState.IsValid) { }

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(users model)
        {
            if (ModelState.IsValid) { }
            return View(model);
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}

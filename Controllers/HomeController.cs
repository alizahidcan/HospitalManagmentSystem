using HospitalManagment.Data;
using HospitalManagment.Models;
using HospitalManagment.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Diagnostics;


namespace HospitalManagment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private LanguageService _localization;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, LanguageService localization, ApplicationDbContext context)
        {
            _logger = logger;
            _localization = localization;
            _context = context;
        }

        public IActionResult Index()
        {

            ViewBag.firstWrite = _localization.Getkey("firstWrite").Value;
            ViewBag.Welcome=_localization.Getkey("Welcome").Value;
            ViewBag.departmen = _localization.Getkey("departmen").Value;
            ViewBag.doctor = _localization.Getkey("doctor").Value;
            ViewBag.appointment = _localization.Getkey("appointment").Value;
            ViewBag.maindepart = _localization.Getkey("maindepart").Value;
            ViewBag.departWrite = _localization.Getkey("departWrite").Value;
            ViewBag.doctorWrite = _localization.Getkey("doctorWrite").Value;
            ViewBag.maindepartWrite = _localization.Getkey("maindepartWrite").Value;
            ViewBag.Home = _localization.Getkey("Home").Value;
            ViewBag.view = _localization.Getkey("view").Value;
            ViewBag.privacy = _localization.Getkey("privacy").Value;
            ViewBag.logout = _localization.Getkey("logout").Value;
            ViewBag.Login = _localization.Getkey("Login").Value;
            ViewBag.Register = _localization.Getkey("Register").Value;
            ViewBag.poliHeader = _localization.Getkey("poliHeader").Value;
            ViewBag.poliWrite = _localization.Getkey("poliWrite").Value;
            ViewBag.anaHeader = _localization.Getkey("anaHeader").Value;
            ViewBag.anaWrite = _localization.Getkey("anaWrite").Value;
            ViewBag.lastHeader = _localization.Getkey("lastHeader").Value;
            ViewBag.lastWrite = _localization.Getkey("lastWrite").Value;




            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
            return View();
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),new CookieOptions()
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult appointment()
        {
            ViewData["departmentId"] = new SelectList(_context.Departments, "Id", "Name");

            if (ViewData["departmentId"]=="1") {
                List<SelectListItem> doctor = new List<SelectListItem>();
                doctor.Add(new SelectListItem() { Text="Dr.Gregory House",Value="1"});
                ViewBag.doctor = doctor;
            }
            else if(ViewData["departmentId"] == "2")
            {
                List<SelectListItem> doctor = new List<SelectListItem>();
                doctor.Add(new SelectListItem() { Text = "Dr.James Wilson", Value = "4" });
                ViewBag.doctor = doctor;
            }
            else if (ViewData["departmentId"] == "3")
            {
                List<SelectListItem> doctor = new List<SelectListItem>();

                doctor.Add(new SelectListItem() { Text = "Dr.Allison Cameron", Value = "2" });
                ViewBag.doctor = doctor;
            }
            else if (ViewData["departmentId"] == "4")
            {
                List<SelectListItem> doctor = new List<SelectListItem>();

                doctor.Add(new SelectListItem() { Text = "Dr.Eric Foreman", Value = "3" });
                ViewBag.doctor = doctor;
            }
            else if (ViewData["departmentId"] == "5")
            {
                List<SelectListItem> doctor = new List<SelectListItem>();

                doctor.Add(new SelectListItem() { Text = "Dr.Gregory House", Value = "1" });
                ViewBag.doctor = doctor;
            }
            else if (ViewData["departmentId"] == "6")
            {
                List<SelectListItem> doctor = new List<SelectListItem>();

                doctor.Add(new SelectListItem() { Text = "Dr.Gregory House", Value = "1" });
                ViewBag.doctor = doctor;
            }
            else if (ViewData["departmentId"] == "7")
            {
                List<SelectListItem> doctor = new List<SelectListItem>();

                doctor.Add(new SelectListItem() { Text = "Dr.Gregory House", Value = "1" });
                ViewBag.doctor = doctor;
            }
            else if (ViewData["departmentId"] == "8")
            {
                List<SelectListItem> doctor = new List<SelectListItem>();

                doctor.Add(new SelectListItem() { Text = "Dr.Gregory House", Value = "1" });
                ViewBag.doctor = doctor;
            }
            else
            {
                List<SelectListItem> doctor = new List<SelectListItem>();
                doctor.Add(new SelectListItem() { Text = "Dr.James Wilson", Value = "4" });
                ViewBag.doctor = doctor;
            }
            return View();
        }
        [HttpPost]
        public IActionResult appointment(takeAppointment appointment)
        {
            if (ModelState.IsValid)
            {
                appointment appo = new()
                {
                    userName = @User.FindFirst("Name").Value,
                    justDate = appointment.justDate,
                    time = appointment.time,
                    departmentId = appointment.departmentId,
                    doctorId = appointment.doctorId,
                };
                _context.Appointments.Add(appo);
                int affectedRowCount = _context.SaveChanges();
                if (affectedRowCount == 0)
                {
                    ModelState.AddModelError("", "User couldnt be added");
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(appointment);
        }

        public async Task<IActionResult> departments()
        {
            return View(await _context.Departments.ToListAsync());
        }

        public async Task<IActionResult> doctors()
        {
            var applicationDbContext = _context.Doctors.Include(d => d.department);
            return View(await applicationDbContext.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

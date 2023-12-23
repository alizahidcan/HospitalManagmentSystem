using HospitalManagment.Models;
using HospitalManagment.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace HospitalManagment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private LanguageService _localization;
        public HomeController(ILogger<HomeController> logger,LanguageService localization)
        {
            _logger = logger;
            _localization = localization;
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
            ViewBag.view = _localization.Getkey("view").Value;


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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

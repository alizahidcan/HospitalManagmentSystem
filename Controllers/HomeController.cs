using HospitalManagment.Data;
using HospitalManagment.Models;
using HospitalManagment.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            ViewBag.appo = _localization.Getkey("appo").Value;
            ViewBag.appoWrite = _localization.Getkey("appoWrite").Value;


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
            SelectList departmentData = new SelectList(_context.Departments, "Id", "Name");

            takeAppointment model = new takeAppointment()
            {
                DepartmentData = departmentData,

                // Baþlangýçta þehir verisi yoktur ama kayýt düzenleme yaparsanýz burayý da doldurunuz.
                DoctorData = new SelectList(new List<doctors>())
            };
            
            return View(model);
        }

        [HttpPost]
        public IActionResult appointment(takeAppointment model)
        {           
                SelectList departmentData = new SelectList(_context.Departments, "Id", "Name");
                SelectList doctorData = new SelectList(_context.Doctors, "id", "name");
                model.DepartmentData = departmentData;
                model.DoctorData = doctorData;
                DateTime dt = DateTime.Now;
            var start = TimeOnly.Parse("9:00 AM");
            var finish = TimeOnly.Parse("6:00 PM");
            if (model.justDate < DateOnly.FromDateTime(dt))
            {
                ModelState.AddModelError(nameof(model.justDate), "Please dont select past :)");
                return View(model);
            }
            else if (model.time<start||model.time>finish) {
                ModelState.AddModelError(nameof(model.time), "Our Working hours is : 09-18");
                return View(model);
            }
            else
            {
                if(_context.Appointments.Any(x=>x.justDate==model.justDate)) { 
                    if(_context.Appointments.Any(x=>x.doctorId==model.SelectedDoctorId))
                    {
                        if(_context.Appointments.Any(x=>x.time==model.time))
                        {
                            ModelState.AddModelError(nameof(model.time), "This time is selected by different user");
                            return View(model);
                        }
                        else
                        {
                            appointment appo = new()
                            {
                                userName = @User.FindFirst("Name").Value,
                                justDate = model.justDate,
                                time = model.time,
                                departmentId = model.SelectedDepartmentId,
                                doctorId = model.SelectedDoctorId,
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
                    }
                    else
                    {
                        appointment appo = new()
                        {
                            userName = @User.FindFirst("Name").Value,
                            justDate = model.justDate,
                            time = model.time,
                            departmentId = model.SelectedDepartmentId,
                            doctorId = model.SelectedDoctorId,
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
                }
                else { 
                appointment appo = new()
                {
                    userName = @User.FindFirst("Name").Value,
                    justDate = model.justDate,
                    time = model.time,
                    departmentId = model.SelectedDepartmentId,
                    doctorId = model.SelectedDoctorId,
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
            }
            
            return View(model);
        }

        public async Task<IActionResult> ShowAppointment()
        {
            var applicationDbContext = _context.Appointments.Include(a => a.department).Include(a => a.doctors);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> ShowAppointmentDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.department)
                .Include(a => a.doctors)
                .FirstOrDefaultAsync(m => m.id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: appointments/Delete/5
        [HttpPost, ActionName("ShowAppointmentDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ShowAppointment));
        }

        public JsonResult GetCitiesByCountry(int id)
        {
            return Json(_context.Doctors.Where(doc => doc.departmentId == id).ToList());
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

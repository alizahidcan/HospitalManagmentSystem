using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalManagment.Data;
using HospitalManagment.Models;

namespace HospitalManagment.Views
{
    public class doctorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public doctorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: doctors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Doctors.Include(d => d.department);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctors = await _context.Doctors
                .Include(d => d.department)
                .FirstOrDefaultAsync(m => m.id == id);
            if (doctors == null)
            {
                return NotFound();
            }

            return View(doctors);
        }

        // GET: doctors/Create
        public IActionResult Create()
        {
            ViewData["departmentId"] = new SelectList(_context.Departments, "Id", "role");
            return View();
        }

        // POST: doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,age,name,Image,Description,holidayDay,workingHours,departmentId")] doctors doctors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["departmentId"] = new SelectList(_context.Departments, "Id", "role", doctors.departmentId);
            return View(doctors);
        }

        // GET: doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctors = await _context.Doctors.FindAsync(id);
            if (doctors == null)
            {
                return NotFound();
            }
            ViewData["departmentId"] = new SelectList(_context.Departments, "Id", "role", doctors.departmentId);
            return View(doctors);
        }

        // POST: doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,age,name,Image,Description,holidayDay,workingHours,departmentId")] doctors doctors)
        {
            if (id != doctors.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!doctorsExists(doctors.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["departmentId"] = new SelectList(_context.Departments, "Id", "role", doctors.departmentId);
            return View(doctors);
        }

        // GET: doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctors = await _context.Doctors
                .Include(d => d.department)
                .FirstOrDefaultAsync(m => m.id == id);
            if (doctors == null)
            {
                return NotFound();
            }

            return View(doctors);
        }

        // POST: doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctors = await _context.Doctors.FindAsync(id);
            if (doctors != null)
            {
                _context.Doctors.Remove(doctors);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool doctorsExists(int id)
        {
            return _context.Doctors.Any(e => e.id == id);
        }
    }
}

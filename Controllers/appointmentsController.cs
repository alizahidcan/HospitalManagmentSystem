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
    public class appointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public appointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: appointments

        public IActionResult appointment()
        {
            ViewData["departmentId"] = new SelectList(_context.Departments, "Id", "Name");
            ViewData["doctorId"] = new SelectList(_context.Doctors, "id", "name");
            ViewData["userId"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Appointments.Include(a => a.department).Include(a => a.doctors).Include(a => a.users);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.department)
                .Include(a => a.doctors)
                .Include(a => a.users)
                .FirstOrDefaultAsync(m => m.id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: appointments/Create
        public IActionResult Create()
        {
            ViewData["departmentId"] = new SelectList(_context.Departments, "Id", "Name");
            ViewData["doctorId"] = new SelectList(_context.Doctors, "id", "name");
            ViewData["userId"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // POST: appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,justDate,time,userId,doctorId,departmentId")] appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["departmentId"] = new SelectList(_context.Departments, "Id", "role", appointment.departmentId);
            ViewData["doctorId"] = new SelectList(_context.Doctors, "id", "id", appointment.doctorId);
            ViewData["userId"] = new SelectList(_context.Users, "Id", "role", appointment.userId);
            return View(appointment);
        }

        // GET: appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["departmentId"] = new SelectList(_context.Departments, "Id", "role", appointment.departmentId);
            ViewData["doctorId"] = new SelectList(_context.Doctors, "id", "id", appointment.doctorId);
            ViewData["userId"] = new SelectList(_context.Users, "Id", "role", appointment.userId);
            return View(appointment);
        }

        // POST: appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,justDate,time,userId,doctorId,departmentId")] appointment appointment)
        {
            if (id != appointment.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!appointmentExists(appointment.id))
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
            ViewData["departmentId"] = new SelectList(_context.Departments, "Id", "role", appointment.departmentId);
            ViewData["doctorId"] = new SelectList(_context.Doctors, "id", "id", appointment.doctorId);
            ViewData["userId"] = new SelectList(_context.Users, "Id", "role", appointment.userId);
            return View(appointment);
        }

        // GET: appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.department)
                .Include(a => a.doctors)
                .Include(a => a.users)
                .FirstOrDefaultAsync(m => m.id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool appointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.id == id);
        }
    }
}

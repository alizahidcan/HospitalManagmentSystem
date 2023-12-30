using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalManagment.Data;
using HospitalManagment.Models;

namespace HospitalManagment.Controllers
{
    public class appointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public appointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: appointments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Appointments.Include(a => a.department).Include(a => a.doctors);
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
                .FirstOrDefaultAsync(m => m.id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: appointments/Create

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
            ViewData["departmentId"] = new SelectList(_context.Departments, "Id", "Name", appointment.departmentId);
            ViewData["doctorId"] = new SelectList(_context.Doctors, "id", "Name", appointment.doctorId);
            return View(appointment);
        }

        // POST: appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,justDate,time,userName,doctorId,departmentId")] appointment appointment)
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
            ViewData["departmentId"] = new SelectList(_context.Departments, "Id", "Name", appointment.departmentId);
            ViewData["doctorId"] = new SelectList(_context.Doctors, "id", "name", appointment.doctorId);
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

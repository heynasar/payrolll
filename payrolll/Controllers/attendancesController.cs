using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using payrolll.Data;
using payrolll.Models;

namespace payrolll.Controllers
{
    public class attendancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public attendancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: attendances
        public async Task<IActionResult> Index()
        {
              return _context.attendance != null ? 
                          View(await _context.attendance.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.attendance'  is null.");
        }

        // GET: attendances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.attendance == null)
            {
                return NotFound();
            }

            var attendance = await _context.attendance
                .FirstOrDefaultAsync(m => m.Empid == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // GET: attendances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: attendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Empid,Emp_Name,Date_TimeIN,Date_TimeOut")] attendance attendance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attendance);
        }

        // GET: attendances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.attendance == null)
            {
                return NotFound();
            }

            var attendance = await _context.attendance.FindAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }
            return View(attendance);
        }

        // POST: attendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Empid,Emp_Name,Date_TimeIN,Date_TimeOut")] attendance attendance)
        {
            if (id != attendance.Empid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!attendanceExists(attendance.Empid))
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
            return View(attendance);
        }

        // GET: attendances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.attendance == null)
            {
                return NotFound();
            }

            var attendance = await _context.attendance
                .FirstOrDefaultAsync(m => m.Empid == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // POST: attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.attendance == null)
            {
                return Problem("Entity set 'ApplicationDbContext.attendance'  is null.");
            }
            var attendance = await _context.attendance.FindAsync(id);
            if (attendance != null)
            {
                _context.attendance.Remove(attendance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool attendanceExists(int id)
        {
          return (_context.attendance?.Any(e => e.Empid == id)).GetValueOrDefault();
        }
    }
}

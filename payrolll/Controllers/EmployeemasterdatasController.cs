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
    public class EmployeemasterdatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeemasterdatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employeemasterdatas
        public async Task<IActionResult> Index()
        {
              return _context.Employeemasterdata != null ? 
                          View(await _context.Employeemasterdata.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Employeemasterdata'  is null.");
        }

        // GET: Employeemasterdatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employeemasterdata == null)
            {
                return NotFound();
            }

            var employeemasterdata = await _context.Employeemasterdata
                .FirstOrDefaultAsync(m => m.Empid == id);
            if (employeemasterdata == null)
            {
                return NotFound();
            }

            return View(employeemasterdata);
        }

        // GET: Employeemasterdatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employeemasterdatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Empid,EmpName,JobTitle,Position,Department,WA_Country,WA_City,WA_Block,WA_street,WA_Religion,HA_Country,HA_City,HA_Block,HA_street,HA_Religion")] Employeemasterdata employeemasterdata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeemasterdata);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeemasterdata);
        }

        // GET: Employeemasterdatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employeemasterdata == null)
            {
                return NotFound();
            }

            var employeemasterdata = await _context.Employeemasterdata.FindAsync(id);
            if (employeemasterdata == null)
            {
                return NotFound();
            }
            return View(employeemasterdata);
        }

        // POST: Employeemasterdatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Empid,EmpName,JobTitle,Position,Department,WA_Country,WA_City,WA_Block,WA_street,WA_Religion,HA_Country,HA_City,HA_Block,HA_street,HA_Religion")] Employeemasterdata employeemasterdata)
        {
            if (id != employeemasterdata.Empid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeemasterdata);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeemasterdataExists(employeemasterdata.Empid))
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
            return View(employeemasterdata);
        }

        // GET: Employeemasterdatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employeemasterdata == null)
            {
                return NotFound();
            }

            var employeemasterdata = await _context.Employeemasterdata
                .FirstOrDefaultAsync(m => m.Empid == id);
            if (employeemasterdata == null)
            {
                return NotFound();
            }

            return View(employeemasterdata);
        }

        // POST: Employeemasterdatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employeemasterdata == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Employeemasterdata'  is null.");
            }
            var employeemasterdata = await _context.Employeemasterdata.FindAsync(id);
            if (employeemasterdata != null)
            {
                _context.Employeemasterdata.Remove(employeemasterdata);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeemasterdataExists(int id)
        {
          return (_context.Employeemasterdata?.Any(e => e.Empid == id)).GetValueOrDefault();
        }
    }
}

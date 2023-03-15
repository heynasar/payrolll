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
    public class AllowancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllowancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Allowances
        public async Task<IActionResult> Index()
        {
              return _context.Allowance != null ? 
                          View(await _context.Allowance.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Allowance'  is null.");
        }

        // GET: Allowances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Allowance == null)
            {
                return NotFound();
            }

            var allowance = await _context.Allowance
                .FirstOrDefaultAsync(m => m.Empid == id);
            if (allowance == null)
            {
                return NotFound();
            }

            return View(allowance);
        }

        // GET: Allowances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Allowances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Empid,Emp_Name,Allowance_code,Allowance_Type,Amount,Effective_Date")] Allowance allowance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allowance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allowance);
        }

        // GET: Allowances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Allowance == null)
            {
                return NotFound();
            }

            var allowance = await _context.Allowance.FindAsync(id);
            if (allowance == null)
            {
                return NotFound();
            }
            return View(allowance);
        }

        // POST: Allowances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Empid,Emp_Name,Allowance_code,Allowance_Type,Amount,Effective_Date")] Allowance allowance)
        {
            if (id != allowance.Empid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allowance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllowanceExists(allowance.Empid))
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
            return View(allowance);
        }

        // GET: Allowances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Allowance == null)
            {
                return NotFound();
            }

            var allowance = await _context.Allowance
                .FirstOrDefaultAsync(m => m.Empid == id);
            if (allowance == null)
            {
                return NotFound();
            }

            return View(allowance);
        }

        // POST: Allowances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Allowance == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Allowance'  is null.");
            }
            var allowance = await _context.Allowance.FindAsync(id);
            if (allowance != null)
            {
                _context.Allowance.Remove(allowance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllowanceExists(int id)
        {
          return (_context.Allowance?.Any(e => e.Empid == id)).GetValueOrDefault();
        }
    }
}

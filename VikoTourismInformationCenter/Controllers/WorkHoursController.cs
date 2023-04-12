using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VikoTourismInformationCenter.Data;
using VikoTourismInformationCenter.Models;

namespace VikoTourismInformationCenter.Controllers
{
    public class WorkHoursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkHoursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkHours
        public async Task<IActionResult> Index()
        {
              return _context.WorkHours != null ? 
                          View(await _context.WorkHours.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.WorkHours'  is null.");
        }

        // GET: WorkHours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WorkHours == null)
            {
                return NotFound();
            }

            var workHours = await _context.WorkHours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workHours == null)
            {
                return NotFound();
            }

            return View(workHours);
        }

        // GET: WorkHours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkHours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateFrom,DateTo,WeekDays")] WorkHours workHours)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workHours);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workHours);
        }

        // GET: WorkHours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WorkHours == null)
            {
                return NotFound();
            }

            var workHours = await _context.WorkHours.FindAsync(id);
            if (workHours == null)
            {
                return NotFound();
            }
            return View(workHours);
        }

        // POST: WorkHours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateFrom,DateTo,WeekDays")] WorkHours workHours)
        {
            if (id != workHours.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workHours);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkHoursExists(workHours.Id))
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
            return View(workHours);
        }

        // GET: WorkHours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WorkHours == null)
            {
                return NotFound();
            }

            var workHours = await _context.WorkHours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workHours == null)
            {
                return NotFound();
            }

            return View(workHours);
        }

        // POST: WorkHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WorkHours == null)
            {
                return Problem("Entity set 'ApplicationDbContext.WorkHours'  is null.");
            }
            var workHours = await _context.WorkHours.FindAsync(id);
            if (workHours != null)
            {
                _context.WorkHours.Remove(workHours);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkHoursExists(int id)
        {
          return (_context.WorkHours?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

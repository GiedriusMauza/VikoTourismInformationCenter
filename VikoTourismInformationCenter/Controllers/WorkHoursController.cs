using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VikoTourismInformationCenter.Data;
using VikoTourismInformationCenter.Models;

namespace VikoTourismInformationCenter.Controllers
{
    [Authorize]
    public class WorkHoursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkHoursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkHours
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Index()
        {
            var workHoursList = await _context.WorkHours.ToListAsync();
            var placesList = await _context.Places.ToListAsync();

            foreach (var hours in workHoursList)
            {
                if (hours != null && hours.Place != null)
                {
                    hours.PlaceName = placesList.FirstOrDefault(x => x == hours.Place).Name;
                }
                else
                {
                    hours.PlaceName = "None";
                }

            }

            return View(workHoursList);
        }

        // GET: WorkHours/Details/5
        [Authorize(Roles = "Admin,Manager")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["Place"] = new SelectList(_context.Places, "Id", "Name");
            return View();
        }

        // POST: WorkHours/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateFrom,DateTo,WeekDays, Place")] WorkHours workHours)
        {
            if (ModelState.IsValid)
            {
                var placeId = HttpContext.Request.Form["Place"].ToString();
                var place = await _context.Places.FindAsync(int.Parse(placeId));
                workHours.Place = place;

                _context.Add(workHours);
                await _context.SaveChangesAsync();
                ViewData["Place"] = new SelectList(_context.Places, "Id", "Name", workHours.Place);
                return RedirectToAction(nameof(Index));
            }
            return View(workHours);
        }

        // GET: WorkHours/Edit/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

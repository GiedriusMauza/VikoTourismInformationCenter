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
    public class HeadphonesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HeadphonesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Headphones
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Index(string search)
        {
            var headphonesList = await _context.Headphones.ToListAsync();
            var excursionsList = await _context.Excursions.ToListAsync();

            if (!String.IsNullOrEmpty(search))
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(await _context.Headphones.Where(x => x.Model.Contains(search) || search == null).ToListAsync());
            }

            foreach (var headphone in headphonesList)
            {
                if (headphone != null && headphone.Excursion != null)
                {
                    headphone.ExcursionName = excursionsList.FirstOrDefault(x => x == headphone.Excursion).Name;
                }
                else
                {
                    headphone.ExcursionName = "None";
                }

            }

            return View(headphonesList);

            
        }

        // GET: Headphones/Details/5
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Headphones == null)
            {
                return NotFound();
            }

            var headphones = await _context.Headphones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (headphones == null)
            {
                return NotFound();
            }

            return View(headphones);
        }

        // GET: Headphones/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["Excursions"] = new SelectList(_context.Excursions, "Id", "Name");
            return View();
        }

        // POST: Headphones/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model")] Headphones headphones)
        {
            if (ModelState.IsValid)
            {
                var excursionId = HttpContext.Request.Form["Excursion"].ToString();
                var excursion = await _context.Excursions.FindAsync(int.Parse(excursionId));
                headphones.Excursion = excursion;

                _context.Add(headphones);
                await _context.SaveChangesAsync();
                ViewData["Excursions"] = new SelectList(_context.Places, "Id", "Name", headphones.Excursion);
                return RedirectToAction(nameof(Index));
            }
            return View(headphones);
        }

        // GET: Headphones/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Headphones == null)
            {
                return NotFound();
            }

            var headphones = await _context.Headphones.FindAsync(id);
            if (headphones == null)
            {
                return NotFound();
            }
            return View(headphones);
        }

        // POST: Headphones/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model")] Headphones headphones)
        {
            if (id != headphones.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(headphones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeadphonesExists(headphones.Id))
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
            return View(headphones);
        }

        // GET: Headphones/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Headphones == null)
            {
                return NotFound();
            }

            var headphones = await _context.Headphones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (headphones == null)
            {
                return NotFound();
            }

            return View(headphones);
        }

        // POST: Headphones/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Headphones == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Headphones'  is null.");
            }
            var headphones = await _context.Headphones.FindAsync(id);
            if (headphones != null)
            {
                _context.Headphones.Remove(headphones);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        private bool HeadphonesExists(int id)
        {
          return (_context.Headphones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

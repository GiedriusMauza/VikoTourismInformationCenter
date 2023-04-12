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
    public class HeadphonesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HeadphonesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Headphones
        public async Task<IActionResult> Index()
        {
              return _context.Headphones != null ? 
                          View(await _context.Headphones.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Headphones'  is null.");
        }

        // GET: Headphones/Details/5
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: Headphones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model")] Headphones headphones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(headphones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(headphones);
        }

        // GET: Headphones/Edit/5
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        private bool HeadphonesExists(int id)
        {
          return (_context.Headphones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

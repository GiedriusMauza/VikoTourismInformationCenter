﻿using System;
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
    public class ExcursionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExcursionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Excursions
        public async Task<IActionResult> Index()
        {
              return _context.Excursions != null ? 
                          View(await _context.Excursions.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Excursions'  is null.");
        }

        // GET: Excursions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Excursions == null)
            {
                return NotFound();
            }

            var excursions = await _context.Excursions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (excursions == null)
            {
                return NotFound();
            }

            return View(excursions);
        }

        // GET: Excursions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Excursions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price")] Excursions excursions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(excursions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(excursions);
        }

        // GET: Excursions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Excursions == null)
            {
                return NotFound();
            }

            var excursions = await _context.Excursions.FindAsync(id);
            if (excursions == null)
            {
                return NotFound();
            }
            return View(excursions);
        }

        // POST: Excursions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price")] Excursions excursions)
        {
            if (id != excursions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(excursions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExcursionsExists(excursions.Id))
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
            return View(excursions);
        }

        // GET: Excursions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Excursions == null)
            {
                return NotFound();
            }

            var excursions = await _context.Excursions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (excursions == null)
            {
                return NotFound();
            }

            return View(excursions);
        }

        // POST: Excursions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Excursions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Excursions'  is null.");
            }
            var excursions = await _context.Excursions.FindAsync(id);
            if (excursions != null)
            {
                _context.Excursions.Remove(excursions);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExcursionsExists(int id)
        {
          return (_context.Excursions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
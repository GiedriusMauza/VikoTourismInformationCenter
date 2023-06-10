using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VikoTourismInformationCenter.Data;
using VikoTourismInformationCenter.Models;

namespace VikoTourismInformationCenter.Controllers
{
    [Authorize]
    public class LanguagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LanguagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Languages
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Index(string search, string sortOrder)
        {

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var languages =  _context.Languages.Select(x => x);


            if (!String.IsNullOrEmpty(search))
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(await _context.Languages.Where(x => x.Language.StartsWith(search) || search == null).ToListAsync());
            }
            switch (sortOrder)
            {
                case "name_desc":
                    languages = languages.OrderByDescending(s => s.Language);
                    break;
                default:
                    languages = languages.OrderBy(s => s.Language);
                    break;
            }
            return View(languages);


             
        }

        // GET: Languages/Details/5
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Languages == null)
            {
                return NotFound();
            }

            var languages = await _context.Languages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (languages == null)
            {
                return NotFound();
            }

            return View(languages);
        }

        // GET: Languages/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Languages/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Language")] Languages languages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(languages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(languages);
        }

        // GET: Languages/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Languages == null)
            {
                return NotFound();
            }

            var languages = await _context.Languages.FindAsync(id);
            if (languages == null)
            {
                return NotFound();
            }
            return View(languages);
        }

        // POST: Languages/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Language")] Languages languages)
        {
            if (id != languages.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(languages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanguagesExists(languages.Id))
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
            return View(languages);
        }

        // GET: Languages/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Languages == null)
            {
                return NotFound();
            }

            var languages = await _context.Languages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (languages == null)
            {
                return NotFound();
            }

            return View(languages);
        }

        // POST: Languages/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Languages == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Languages'  is null.");
            }
            var languages = await _context.Languages.FindAsync(id);
            if (languages != null)
            {
                _context.Languages.Remove(languages);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LanguagesExists(int id)
        {
          return (_context.Languages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

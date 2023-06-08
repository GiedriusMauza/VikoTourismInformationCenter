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
    public class ExcursionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExcursionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string option, string search)
        {
            var excursionList = await _context.Excursions.ToListAsync();
            var userList = await _context.ApplicationUser.ToListAsync();
            var languagesList = await _context.Languages.ToListAsync();
            var excursionsLanguagesList = await _context.ExcursionsLanguages.ToListAsync();

            // Languages
            foreach (var excursion in excursionList)
            {
                if (excursion != null)
                {
                    var allexcursionItemsWithAssignedLang = excursionsLanguagesList.Where(x => x.Excursion == excursion);

                    foreach (var item in allexcursionItemsWithAssignedLang)
                    {
                        var assignedLangList = languagesList.Where(x => x == item.Language);
                        foreach (var item1 in assignedLangList)
                        {
                            excursion.LanguagesAvailable += item1.Language + "; ";
                        }
                    }



                    /* excursion.LanguagesList = ;*/
                }
                else
                {
                    excursion.LanguagesAvailable = "None";
                }
            }

            // Email
            foreach (var excursion in excursionList)
            {
                if (excursion != null && excursion.ApplicationUser != null)
                {
                    excursion.UserEmailAddress = userList.FirstOrDefault(x => x == excursion.ApplicationUser).Email;
                }
                else
                {
                    excursion.UserEmailAddress = "None";
                }
            }

            // Search
            if (option == "Name")
            {
                return View(_context.Excursions.Where(x => x.Name.Contains(search) || search == null).ToList());
            }
            else if (option == "Description")
            {
                return View(_context.Excursions.Where(x => x.Description.Contains(search) || search == null).ToList());
            }
            else if (option == "Price")
            {
                return View(_context.Excursions.Where(x => x.Price.ToString().Contains(search) || search == null).ToList());
            }
            else
            {
                return _context.Excursions != null ?
              View(await _context.Excursions.ToListAsync()) :
              Problem("Entity set 'ApplicationDbContext.Excursions'  is null.");
            }

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> PublicIndex(string option, string search)
        {
            var excursionList = await _context.Excursions.ToListAsync();
            var userList = await _context.ApplicationUser.ToListAsync();
            var languagesList = await _context.Languages.ToListAsync();
            var excursionsLanguagesList = await _context.ExcursionsLanguages.ToListAsync();

            // Languages
            foreach (var excursion in excursionList)
            {
                if (excursion != null)
                {
                    var allexcursionItemsWithAssignedLang = excursionsLanguagesList.Where(x => x.Excursion == excursion);

                    foreach (var item in allexcursionItemsWithAssignedLang)
                    {
                        var assignedLangList = languagesList.Where(x => x == item.Language);
                        foreach (var item1 in assignedLangList)
                        {
                            excursion.LanguagesAvailable += item1.Language + "; ";
                        }
                    }
                }
                else
                {
                    excursion.LanguagesAvailable = "None";
                }
            }

            // Email
            foreach (var excursion in excursionList)
            {
                if (excursion != null && excursion.ApplicationUser != null)
                {
                    excursion.UserEmailAddress = userList.FirstOrDefault(x => x == excursion.ApplicationUser).Email;
                }
                else
                {
                    excursion.UserEmailAddress = "None";
                }
            }

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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> PublicDetails(int? id)
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

            ViewBag.Headphones = await _context.Headphones.ToListAsync();

            ViewBag.Languages = await _context.Languages.ToListAsync();
            ViewBag.ExcursionsLanguages = await _context.ExcursionsLanguages.ToListAsync();

            ViewBag.Places = await _context.Places.ToListAsync();
            ViewBag.ExcursionsPlaces = await _context.ExcursionsPlaces.ToListAsync();

            ViewBag.ApplicationUser = await _context.ApplicationUser.ToListAsync();
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

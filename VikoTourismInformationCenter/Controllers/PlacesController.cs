using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using VikoTourismInformationCenter.Data;
using VikoTourismInformationCenter.Models;

namespace VikoTourismInformationCenter.Controllers
{
    public class PlacesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Places
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Places.Include(p => p.Addresses);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Public Places
        public async Task<IActionResult> PublicIndex()
        {
            var placesList = await _context.Places.ToListAsync();
            var categoriesList = await _context.Categories.ToListAsync();
            var placesCategoriesList = await _context.PlacesCategories.ToListAsync();

            // Categories
            foreach (var place in placesList)
            {
                if (place != null)
                {
                    var allplacesItemsWithAssignedCategorie = placesCategoriesList.Where(x => x.Place == place);

                    foreach (var item in allplacesItemsWithAssignedCategorie)
                    {
                        var assignedCategorieList = categoriesList.Where(x => x == item.Category);
                        foreach (var item1 in assignedCategorieList)
                        {
                            place.CategoryName = item1.Name;
                        }
                    }
                }
                else
                {
                    place.CategoryName = "None";
                }
            }

            /*            var applicationDbContext = _context.Places.Include(p => p.Addresses);
                        return View(await applicationDbContext.ToListAsync());*/

            ViewBag.Categories = categoriesList;
            return _context.Places != null ?
                View(await _context.Places.ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.Places' is null.");

        }

        // GET: Places/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Places == null)
            {
                return NotFound();
            }

            var places = await _context.Places
                .Include(p => p.Addresses)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (places == null)
            {
                return NotFound();
            }

            return View(places);
        }

        // GET: Public Places/Details/5
        public async Task<IActionResult> PublicDetails(int? id)
        {
            if (id == null || _context.Places == null)
            {
                return NotFound();
            }

            var places = await _context.Places
                .Include(p => p.Addresses)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (places == null)
            {
                return NotFound();
            }

            return View(places);
        }

        // GET: Places/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Addresses, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Places places)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(places);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    TempData[SD.Error] = "Error. Address already assigned!";
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Addresses, "Id", "City", places.Id);
            return View(places);
        }

        // GET: Places/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Places == null)
            {
                return NotFound();
            }

            var places = await _context.Places.FindAsync(id);
            if (places == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Addresses, "Id", "City", places.Id);
            return View(places);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Places places)
        {
            if (id != places.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(places);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacesExists(places.Id))
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
            ViewData["Id"] = new SelectList(_context.Addresses, "Id", "City", places.Id);
            return View(places);
        }

        // GET: Places/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Places == null)
            {
                return NotFound();
            }

            var places = await _context.Places
                .Include(p => p.Addresses)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (places == null)
            {
                return NotFound();
            }

            return View(places);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Places == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Places'  is null.");
            }
            var places = await _context.Places.FindAsync(id);
            if (places != null)
            {
                _context.Places.Remove(places);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlacesExists(int id)
        {
          return (_context.Places?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

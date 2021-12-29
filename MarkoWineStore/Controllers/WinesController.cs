using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarkoWineStore.Data;
using MarkoWineStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using PagedList;
using Microsoft.AspNetCore.Authorization;

namespace MarkoWineStore.Controllers
{
    public class WinesController : Controller
    {
        private readonly MarkoWineStoreContext _context;

        public WinesController(MarkoWineStoreContext context)
        {
            _context = context;
        }

        // GET: Wines
        public async Task<IActionResult> Index(string searchString, int page = 0)
        {
            var wines = _context.Wine.ToList();
            
            //var wines = from m in _context.Wine
            //             select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                wines = wines.Where(s => s.Name.ToLower()!.Contains(searchString.ToLower())).ToList();
            }

            const int PageSize = 12;
            var count = wines.Count();
            wines = wines.Skip(page * PageSize).Take(PageSize).ToList();

            this.ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);
            this.ViewBag.Page = page;

            return View(wines);
        }
        public async Task<IActionResult> WineList()
        {
            return View(await _context.Wine.ToListAsync());
        }

        public IActionResult Category(string Category)
        {
            var wines = _context.Wine.ToList();

            switch (Category)
            {
                case "Red":
                    wines = wines.Where(s => s.Category.Contains(Category)).ToList();
                    break;
                case "White":
                    wines = wines.Where(s => s.Category.Contains(Category)).ToList();
                    break;
                case "Sparkling":
                    wines = wines.Where(s => s.Category.Contains(Category)).ToList();
                    break;
            }

            return View(wines);
        }

        // GET: Wines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wine = await _context.Wine
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wine == null)
            {
                return NotFound();
            }

            return View(wine);
        }

        // GET: Wines/Create

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Picture,Description,Category,StringRes1,StringRes2,Stock,IntRes1,IntRes2,Price")] Wine wine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wine);
        }

        // GET: Wines/Edit/5

        [Authorize(Roles = "Admin, Editor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wine = await _context.Wine.FindAsync(id);
            if (wine == null)
            {
                return NotFound();
            }
            return View(wine);
        }

        // POST: Wines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Picture,Description,Category,StringRes1,StringRes2,Stock,IntRes1,IntRes2,Price")] Wine wine)
        {
            if (id != wine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WineExists(wine.Id))
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
            return View(wine);
        }

        // GET: Wines/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wine = await _context.Wine
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wine == null)
            {
                return NotFound();
            }

            return View(wine);
        }

        // POST: Wines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wine = await _context.Wine.FindAsync(id);
            _context.Wine.Remove(wine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WineExists(int id)
        {
            return _context.Wine.Any(e => e.Id == id);
        }
    }
}

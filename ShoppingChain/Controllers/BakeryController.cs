using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingChain.Data;
using ShoppingChain.Models;

namespace ShoppingChain.Controllers
{
    public class BakeryController : Controller
    {
        private readonly ShopDb _context;

        public BakeryController(ShopDb context)
        {
            _context = context;
        }

        // GET: Bakery
        public async Task<IActionResult> Index()
        {
            var shopDb = _context.bakeries.Include(b => b.Shop);
            return View(await shopDb.ToListAsync());
        }

        // GET: Bakery/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.bakeries == null)
            {
                return NotFound();
            }

            var bakery = await _context.bakeries
                .Include(b => b.Shop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bakery == null)
            {
                return NotFound();
            }

            return View(bakery);
        }

        // GET: Bakery/Create
        public IActionResult Create()
        {
            ViewData["ShopId"] = new SelectList(_context.shops, "Id", "Id");
            return View();
        }

        // POST: Bakery/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BakeryFor,PhoneNumber,ShopId")] Bakery bakery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bakery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShopId"] = new SelectList(_context.shops, "Id", "Id", bakery.ShopId);
            return View(bakery);
        }

        // GET: Bakery/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.bakeries == null)
            {
                return NotFound();
            }

            var bakery = await _context.bakeries.FindAsync(id);
            if (bakery == null)
            {
                return NotFound();
            }
            ViewData["ShopId"] = new SelectList(_context.shops, "Id", "Id", bakery.ShopId);
            return View(bakery);
        }

        // POST: Bakery/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BakeryFor,PhoneNumber,ShopId")] Bakery bakery)
        {
            if (id != bakery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bakery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BakeryExists(bakery.Id))
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
            ViewData["ShopId"] = new SelectList(_context.shops, "Id", "Id", bakery.ShopId);
            return View(bakery);
        }

        // GET: Bakery/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.bakeries == null)
            {
                return NotFound();
            }

            var bakery = await _context.bakeries
                .Include(b => b.Shop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bakery == null)
            {
                return NotFound();
            }

            return View(bakery);
        }

        // POST: Bakery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.bakeries == null)
            {
                return Problem("Entity set 'ShopDb.bakeries'  is null.");
            }
            var bakery = await _context.bakeries.FindAsync(id);
            if (bakery != null)
            {
                _context.bakeries.Remove(bakery);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BakeryExists(int id)
        {
          return (_context.bakeries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

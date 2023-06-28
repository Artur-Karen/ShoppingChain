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
    public class StorageController : Controller
    {
        private readonly ShopDb _context;

        public StorageController(ShopDb context)
        {
            _context = context;
        }

        // GET: Storage
        public async Task<IActionResult> Index()
        {
            var shopDb = _context.storages.Include(s => s.Shop);
            return View(await shopDb.ToListAsync());
        }

        // GET: Storage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.storages == null)
            {
                return NotFound();
            }

            var storage = await _context.storages
                .Include(s => s.Shop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storage == null)
            {
                return NotFound();
            }

            return View(storage);
        }

        // GET: Storage/Create
        public IActionResult Create()
        {
            ViewData["ShopId"] = new SelectList(_context.shops, "Id", "Id");
            return View();
        }

        // POST: Storage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PhoneNumber,ShopId")] Storage storage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShopId"] = new SelectList(_context.shops, "Id", "Id", storage.ShopId);
            return View(storage);
        }

        // GET: Storage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.storages == null)
            {
                return NotFound();
            }

            var storage = await _context.storages.FindAsync(id);
            if (storage == null)
            {
                return NotFound();
            }
            ViewData["ShopId"] = new SelectList(_context.shops, "Id", "Id", storage.ShopId);
            return View(storage);
        }

        // POST: Storage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PhoneNumber,ShopId")] Storage storage)
        {
            if (id != storage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StorageExists(storage.Id))
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
            ViewData["ShopId"] = new SelectList(_context.shops, "Id", "Id", storage.ShopId);
            return View(storage);
        }

        // GET: Storage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.storages == null)
            {
                return NotFound();
            }

            var storage = await _context.storages
                .Include(s => s.Shop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storage == null)
            {
                return NotFound();
            }

            return View(storage);
        }

        // POST: Storage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.storages == null)
            {
                return Problem("Entity set 'ShopDb.storages'  is null.");
            }
            var storage = await _context.storages.FindAsync(id);
            if (storage != null)
            {
                _context.storages.Remove(storage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StorageExists(int id)
        {
          return (_context.storages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

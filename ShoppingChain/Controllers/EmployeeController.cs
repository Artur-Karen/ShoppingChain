using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingChain.Data;
using ShoppingChain.Models;

namespace ShoppingChain.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ShopDb _context;

        public EmployeeController(ShopDb context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin,User")]
        // GET: Employee
        public async Task<IActionResult> Index()
        {
            var shopDb = _context.employees.Include(e => e.Bakery).Include(e => e.Shop).Include(e => e.Storage);
            return View(await shopDb.ToListAsync());
        }
        [Authorize(Roles = "Admin,User")]
        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.employees == null)
            {
                return NotFound();
            }

            var employee = await _context.employees
                .Include(e => e.Bakery)
                .Include(e => e.Shop)
                .Include(e => e.Storage)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        [Authorize(Roles = "Admin")]
        // GET: Employee/Create
        public IActionResult Create()
        {
            ViewData["BakeryId"] = new SelectList(_context.bakeries, "Id", "Id");
            ViewData["ShopId"] = new SelectList(_context.shops, "Id", "Id");
            ViewData["StorageId"] = new SelectList(_context.storages, "Id", "Id");
            return View();
        }
        [Authorize(Roles = "Admin")]
        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DateOfEmployment,PhoneNumber,Email,Salary,ShopId,BakeryId,StorageId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BakeryId"] = new SelectList(_context.bakeries, "Id", "Id", employee.BakeryId);
            ViewData["ShopId"] = new SelectList(_context.shops, "Id", "Id", employee.ShopId);
            ViewData["StorageId"] = new SelectList(_context.storages, "Id", "Id", employee.StorageId);
            return View(employee);
        }
        [Authorize(Roles = "Admin")]
        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.employees == null)
            {
                return NotFound();
            }

            var employee = await _context.employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["BakeryId"] = new SelectList(_context.bakeries, "Id", "Id", employee.BakeryId);
            ViewData["ShopId"] = new SelectList(_context.shops, "Id", "Id", employee.ShopId);
            ViewData["StorageId"] = new SelectList(_context.storages, "Id", "Id", employee.StorageId);
            return View(employee);
        }
        [Authorize(Roles = "Admin")]
        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DateOfEmployment,PhoneNumber,Email,Salary,ShopId,BakeryId,StorageId")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            ViewData["BakeryId"] = new SelectList(_context.bakeries, "Id", "Id", employee.BakeryId);
            ViewData["ShopId"] = new SelectList(_context.shops, "Id", "Id", employee.ShopId);
            ViewData["StorageId"] = new SelectList(_context.storages, "Id", "Id", employee.StorageId);
            return View(employee);
        }
        [Authorize(Roles = "Admin")]
        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.employees == null)
            {
                return NotFound();
            }

            var employee = await _context.employees
                .Include(e => e.Bakery)
                .Include(e => e.Shop)
                .Include(e => e.Storage)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        [Authorize(Roles = "Admin")]
        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.employees == null)
            {
                return Problem("Entity set 'ShopDb.employees'  is null.");
            }
            var employee = await _context.employees.FindAsync(id);
            if (employee != null)
            {
                _context.employees.Remove(employee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return (_context.employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

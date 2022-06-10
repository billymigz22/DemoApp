using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoApp.Models;

namespace DemoApp.Controllers
{
    public class FarmerController : Controller
    {
        private readonly FarmerDbContext _context;

        public FarmerController(FarmerDbContext context)
        {
            _context = context;
        }

        // GET: Farmer
        public async Task<IActionResult> Index()
        {
            return _context.Farmers != null ?
                        View(await _context.Farmers.ToListAsync()) :
                        Problem("Entity set 'FarmerDbContext.Farmers'  is null.");
        }

        // GET: Farmer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Farmers == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmers
                .Include(f => f.Farms)
                .FirstOrDefaultAsync(m => m.FarmerId == id);
            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }

        // GET: Farmer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farmer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FarmerId,FirstName,MiddleName,LastName,Gender,BirthDate")] Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farmer);
        }

        // GET: Farmer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Farmers == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer == null)
            {
                return NotFound();
            }
            return View(farmer);
        }

        // POST: Farmer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FarmerId,FirstName,MiddleName,LastName,Gender,BirthDate")] Farmer farmer)
        {
            if (id != farmer.FarmerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmerExists(farmer.FarmerId))
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
            return View(farmer);
        }

        // GET: Farmer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Farmers == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmers
                .FirstOrDefaultAsync(m => m.FarmerId == id);
            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }

        // POST: Farmer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Farmers == null)
            {
                return Problem("Entity set 'FarmerDbContext.Farmers'  is null.");
            }
            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer != null)
            {
                _context.Farmers.Remove(farmer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddFarm(int? id)
        {
            if (id == null || _context.Farmers == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer == null)
            {
                return NotFound();
            }
            ViewData["FarmerId"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> AddFarm([Bind("Hectare,TenurialStatus,FarmAddress,FarmerId")] Farm farm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farm);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = farm.FarmerId});
            }
            return View(farm);
            
        }

        private bool FarmerExists(int id)
        {
          return (_context.Farmers?.Any(e => e.FarmerId == id)).GetValueOrDefault();
        }
    }
}

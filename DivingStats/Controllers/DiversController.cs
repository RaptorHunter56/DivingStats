using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DivingStats.Data;
using DivingStats.Models;
using Microsoft.AspNetCore.Authorization;

namespace DivingStats.Controllers
{
    [Authorize]
    public class DiversController : Controller
    {
        private readonly DiveDbContext _context;

        public DiversController(DiveDbContext context)
        {
            _context = context;
        }

        // GET: Divers
        public async Task<IActionResult> Index()
        {
              return _context.Divers != null ? 
                          View(await _context.Divers.ToListAsync()) :
                          Problem("Entity set 'DiveDbContext.Divers'  is null.");
        }

        // GET: Divers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Divers == null)
            {
                return NotFound();
            }

            var diver = await _context.Divers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (diver == null)
            {
                return NotFound();
            }

            return View(diver);
        }

        // GET: Divers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Divers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,DateOfBirth,Nationality")] Diver diver)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diver);
        }

        // GET: Divers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Divers == null)
            {
                return NotFound();
            }

            var diver = await _context.Divers.FindAsync(id);
            if (diver == null)
            {
                return NotFound();
            }
            return View(diver);
        }

        // POST: Divers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,DateOfBirth,Nationality")] Diver diver)
        {
            if (id != diver.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiverExists(diver.ID))
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
            return View(diver);
        }

        // GET: Divers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Divers == null)
            {
                return NotFound();
            }

            var diver = await _context.Divers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (diver == null)
            {
                return NotFound();
            }

            return View(diver);
        }

        // POST: Divers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Divers == null)
            {
                return Problem("Entity set 'DiveDbContext.Divers'  is null.");
            }
            var diver = await _context.Divers.FindAsync(id);
            if (diver != null)
            {
                _context.Divers.Remove(diver);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiverExists(int id)
        {
          return (_context.Divers?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}

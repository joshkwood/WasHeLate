using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WasJohnLate.Data;
using WasJohnLate.Models;

namespace WasJohnLate.Views
{
    public class TrackingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrackingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tracking
        public async Task<IActionResult> Index()
        {
              return _context.EntryTime != null ? 
                          View(await _context.EntryTime.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.EntryTime'  is null.");
        }

        // GET: Tracking/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.EntryTime == null)
            {
                return NotFound();
            }

            var entryTime = await _context.EntryTime
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entryTime == null)
            {
                return NotFound();
            }

            return View(entryTime);
        }

        // GET: Tracking/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tracking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RecorderName,EntryDateTime,WasJohnLate,EntryLocation")] EntryTime entryTime)
        {
            if (ModelState.IsValid)
            {
                entryTime.Id = Guid.NewGuid();
                _context.Add(entryTime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entryTime);
        }

        // GET: Tracking/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.EntryTime == null)
            {
                return NotFound();
            }

            var entryTime = await _context.EntryTime.FindAsync(id);
            if (entryTime == null)
            {
                return NotFound();
            }
            return View(entryTime);
        }

        // POST: Tracking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,RecorderName,EntryDateTime,WasJohnLate,EntryLocation")] EntryTime entryTime)
        {
            if (id != entryTime.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entryTime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntryTimeExists(entryTime.Id))
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
            return View(entryTime);
        }

        // GET: Tracking/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.EntryTime == null)
            {
                return NotFound();
            }

            var entryTime = await _context.EntryTime
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entryTime == null)
            {
                return NotFound();
            }

            return View(entryTime);
        }

        // POST: Tracking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.EntryTime == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EntryTime'  is null.");
            }
            var entryTime = await _context.EntryTime.FindAsync(id);
            if (entryTime != null)
            {
                _context.EntryTime.Remove(entryTime);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntryTimeExists(Guid id)
        {
          return (_context.EntryTime?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

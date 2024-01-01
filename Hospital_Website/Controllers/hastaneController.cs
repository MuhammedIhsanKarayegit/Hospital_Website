using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital_Website.Data;
using Hospital_Website.Models;

namespace Hospital_Website.Controllers
{
    public class hastaneController : Controller
    {
        private readonly Hospital_WebsiteContext _context;

        public hastaneController(Hospital_WebsiteContext context)
        {
            _context = context;
        }

        // GET: hastane
        public async Task<IActionResult> Index()
        {
            var Hospital_WebsiteContext = _context.hastane.Include(h => h.ilce);
            return View(await Hospital_WebsiteContext.ToListAsync());
        }

        // GET: hastane/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.hastane == null)
            {
                return NotFound();
            }

            var hastane = await _context.hastane
                .Include(h => h.ilce)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hastane == null)
            {
                return NotFound();
            }

            return View(hastane);
        }

        // GET: hastane/Create
        public IActionResult Create()
        {
            ViewData["ilceID"] = new SelectList(_context.Set<ilce>(), "id", "id");
            return View();
        }

        // POST: hastane/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ilceID")] hastane hastane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hastane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ilceID"] = new SelectList(_context.Set<ilce>(), "id", "id", hastane.ilceID);
            return View(hastane);
        }

        // GET: hastane/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.hastane == null)
            {
                return NotFound();
            }

            var hastane = await _context.hastane.FindAsync(id);
            if (hastane == null)
            {
                return NotFound();
            }
            ViewData["ilceID"] = new SelectList(_context.Set<ilce>(), "id", "id", hastane.ilceID);
            return View(hastane);
        }

        // POST: hastane/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ilceID")] hastane hastane)
        {
            if (id != hastane.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hastane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!hastaneExists(hastane.Id))
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
            ViewData["ilceID"] = new SelectList(_context.Set<ilce>(), "id", "id", hastane.ilceID);
            return View(hastane);
        }

        // GET: hastane/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.hastane == null)
            {
                return NotFound();
            }

            var hastane = await _context.hastane
                .Include(h => h.ilce)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hastane == null)
            {
                return NotFound();
            }

            return View(hastane);
        }

        // POST: hastane/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.hastane == null)
            {
                return Problem("Entity set 'Hospital_WebsiteContext.hastane'  is null.");
            }
            var hastane = await _context.hastane.FindAsync(id);
            if (hastane != null)
            {
                _context.hastane.Remove(hastane);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool hastaneExists(int id)
        {
          return (_context.hastane?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

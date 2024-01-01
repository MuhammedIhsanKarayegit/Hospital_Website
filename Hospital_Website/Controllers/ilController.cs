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
    public class ilController : Controller
    {
        private readonly Hospital_WebsiteContext _context;

        public ilController(Hospital_WebsiteContext context)
        {
            _context = context;
        }

        // GET: il
        public async Task<IActionResult> Index()
        {
              return _context.il != null ? 
                          View(await _context.il.ToListAsync()) :
                          Problem("Entity set 'Hospital_WebsiteContext.il'  is null.");
        }

        // GET: il/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.il == null)
            {
                return NotFound();
            }

            var il = await _context.il
                .FirstOrDefaultAsync(m => m.Id == id);
            if (il == null)
            {
                return NotFound();
            }

            return View(il);
        }

        // GET: il/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: il/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] il il)
        {
            if (ModelState.IsValid)
            {
                _context.Add(il);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(il);
        }

        // GET: il/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.il == null)
            {
                return NotFound();
            }

            var il = await _context.il.FindAsync(id);
            if (il == null)
            {
                return NotFound();
            }
            return View(il);
        }

        // POST: il/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] il il)
        {
            if (id != il.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(il);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ilExists(il.Id))
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
            return View(il);
        }

        // GET: il/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.il == null)
            {
                return NotFound();
            }

            var il = await _context.il
                .FirstOrDefaultAsync(m => m.Id == id);
            if (il == null)
            {
                return NotFound();
            }

            return View(il);
        }

        // POST: il/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.il == null)
            {
                return Problem("Entity set 'Hospital_WebsiteContext.il'  is null.");
            }
            var il = await _context.il.FindAsync(id);
            if (il != null)
            {
                _context.il.Remove(il);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ilExists(int id)
        {
          return (_context.il?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

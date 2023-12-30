using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KocamanHastanesi.Data;
using KocamanHastanesi.Models;

namespace KocamanHastanesi.Controllers
{
    public class poliklinikController : Controller
    {
        private readonly KocamanHastanesiContext _context;

        public poliklinikController(KocamanHastanesiContext context)
        {
            _context = context;
        }

        // GET: poliklinik
        public async Task<IActionResult> Index()
        {
            var kocamanHastanesiContext = _context.poliklinik.Include(p => p.hastane);
            return View(await kocamanHastanesiContext.ToListAsync());
        }

        // GET: poliklinik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.poliklinik == null)
            {
                return NotFound();
            }

            var poliklinik = await _context.poliklinik
                .Include(p => p.hastane)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poliklinik == null)
            {
                return NotFound();
            }

            return View(poliklinik);
        }

        // GET: poliklinik/Create
        public IActionResult Create()
        {
            ViewData["hastaneId"] = new SelectList(_context.hastane, "Id", "Id");
            return View();
        }

        // POST: poliklinik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,hastaneId")] poliklinik poliklinik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poliklinik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["hastaneId"] = new SelectList(_context.hastane, "Id", "Id", poliklinik.hastaneId);
            return View(poliklinik);
        }

        // GET: poliklinik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.poliklinik == null)
            {
                return NotFound();
            }

            var poliklinik = await _context.poliklinik.FindAsync(id);
            if (poliklinik == null)
            {
                return NotFound();
            }
            ViewData["hastaneId"] = new SelectList(_context.hastane, "Id", "Id", poliklinik.hastaneId);
            return View(poliklinik);
        }

        // POST: poliklinik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,hastaneId")] poliklinik poliklinik)
        {
            if (id != poliklinik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poliklinik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!poliklinikExists(poliklinik.Id))
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
            ViewData["hastaneId"] = new SelectList(_context.hastane, "Id", "Id", poliklinik.hastaneId);
            return View(poliklinik);
        }

        // GET: poliklinik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.poliklinik == null)
            {
                return NotFound();
            }

            var poliklinik = await _context.poliklinik
                .Include(p => p.hastane)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poliklinik == null)
            {
                return NotFound();
            }

            return View(poliklinik);
        }

        // POST: poliklinik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.poliklinik == null)
            {
                return Problem("Entity set 'KocamanHastanesiContext.poliklinik'  is null.");
            }
            var poliklinik = await _context.poliklinik.FindAsync(id);
            if (poliklinik != null)
            {
                _context.poliklinik.Remove(poliklinik);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool poliklinikExists(int id)
        {
          return (_context.poliklinik?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

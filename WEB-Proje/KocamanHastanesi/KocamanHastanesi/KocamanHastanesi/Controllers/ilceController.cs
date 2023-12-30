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
    public class ilceController : Controller
    {
        private readonly KocamanHastanesiContext _context;

        public ilceController(KocamanHastanesiContext context)
        {
            _context = context;
        }

        // GET: ilce
        public async Task<IActionResult> Index()
        {
            var kocamanHastanesiContext = _context.ilce.Include(i => i.il);
            return View(await kocamanHastanesiContext.ToListAsync());
        }

        // GET: ilce/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ilce == null)
            {
                return NotFound();
            }

            var ilce = await _context.ilce
                .Include(i => i.il)
                .FirstOrDefaultAsync(m => m.id == id);
            if (ilce == null)
            {
                return NotFound();
            }

            return View(ilce);
        }

        // GET: ilce/Create
        public IActionResult Create()
        {
            ViewData["ilID"] = new SelectList(_context.il, "Id", "Id");
            return View();
        }

        // POST: ilce/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,ilID")] ilce ilce)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ilce);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ilID"] = new SelectList(_context.il, "Id", "Id", ilce.ilID);
            return View(ilce);
        }

        // GET: ilce/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ilce == null)
            {
                return NotFound();
            }

            var ilce = await _context.ilce.FindAsync(id);
            if (ilce == null)
            {
                return NotFound();
            }
            ViewData["ilID"] = new SelectList(_context.il, "Id", "Id", ilce.ilID);
            return View(ilce);
        }

        // POST: ilce/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,ilID")] ilce ilce)
        {
            if (id != ilce.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ilce);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ilceExists(ilce.id))
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
            ViewData["ilID"] = new SelectList(_context.il, "Id", "Id", ilce.ilID);
            return View(ilce);
        }

        // GET: ilce/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ilce == null)
            {
                return NotFound();
            }

            var ilce = await _context.ilce
                .Include(i => i.il)
                .FirstOrDefaultAsync(m => m.id == id);
            if (ilce == null)
            {
                return NotFound();
            }

            return View(ilce);
        }

        // POST: ilce/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ilce == null)
            {
                return Problem("Entity set 'KocamanHastanesiContext.ilce'  is null.");
            }
            var ilce = await _context.ilce.FindAsync(id);
            if (ilce != null)
            {
                _context.ilce.Remove(ilce);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ilceExists(int id)
        {
          return (_context.ilce?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}

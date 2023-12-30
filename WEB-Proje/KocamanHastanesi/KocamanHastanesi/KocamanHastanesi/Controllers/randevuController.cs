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
    public class randevuController : Controller
    {
        private readonly KocamanHastanesiContext _context;

        public randevuController(KocamanHastanesiContext context)
        {
            _context = context;
        }

        // GET: randevu
        public async Task<IActionResult> Index()
        {
            var kocamanHastanesiContext = _context.randevu.Include(r => r.doktor).Include(r => r.hasta);
            return View(await kocamanHastanesiContext.ToListAsync());
        }

        // GET: randevu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.randevu == null)
            {
                return NotFound();
            }

            var randevu = await _context.randevu
                .Include(r => r.doktor)
                .Include(r => r.hasta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // GET: randevu/Create
        public IActionResult Create()
        {
            ViewData["doktorID"] = new SelectList(_context.doktor, "id", "id");
            ViewData["hastaID"] = new SelectList(_context.hasta, "id", "id");
            return View();
        }

        // POST: randevu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,hastaID,tarih,doktorID")] randevu randevu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(randevu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["doktorID"] = new SelectList(_context.doktor, "id", "id", randevu.doktorID);
            ViewData["hastaID"] = new SelectList(_context.hasta, "id", "id", randevu.hastaID);
            return View(randevu);
        }

        // GET: randevu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.randevu == null)
            {
                return NotFound();
            }

            var randevu = await _context.randevu.FindAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }
            ViewData["doktorID"] = new SelectList(_context.doktor, "id", "id", randevu.doktorID);
            ViewData["hastaID"] = new SelectList(_context.hasta, "id", "id", randevu.hastaID);
            return View(randevu);
        }

        // POST: randevu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,hastaID,tarih,doktorID")] randevu randevu)
        {
            if (id != randevu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(randevu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!randevuExists(randevu.Id))
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
            ViewData["doktorID"] = new SelectList(_context.doktor, "id", "id", randevu.doktorID);
            ViewData["hastaID"] = new SelectList(_context.hasta, "id", "id", randevu.hastaID);
            return View(randevu);
        }

        // GET: randevu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.randevu == null)
            {
                return NotFound();
            }

            var randevu = await _context.randevu
                .Include(r => r.doktor)
                .Include(r => r.hasta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // POST: randevu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.randevu == null)
            {
                return Problem("Entity set 'KocamanHastanesiContext.randevu'  is null.");
            }
            var randevu = await _context.randevu.FindAsync(id);
            if (randevu != null)
            {
                _context.randevu.Remove(randevu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool randevuExists(int id)
        {
          return (_context.randevu?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

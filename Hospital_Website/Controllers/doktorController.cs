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
    public class doktorController : Controller
    {
        private readonly Hospital_WebsiteContext _context;

        public doktorController(Hospital_WebsiteContext context)
        {
            _context = context;
        }

        // GET: doktor
        public async Task<IActionResult> Index()
        {
            var Hospital_WebsiteContext = _context.doktor.Include(d => d.poliklinik);
            return View(await Hospital_WebsiteContext.ToListAsync());
        }

        // GET: doktor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.doktor == null)
            {
                return NotFound();
            }

            var doktor = await _context.doktor
                .Include(d => d.poliklinik)
                .FirstOrDefaultAsync(m => m.id == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // GET: doktor/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("kullanıcıYetki") != "Admin")
                return RedirectToAction("Index", "Home");
            ViewData["poliklinikid"] = new SelectList(_context.Set<poliklinik>(), "Id", "Id");
            return View();
        }

        // POST: doktor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,tc,poliklinikid,sifre")] doktor doktor)
        {
           
                _context.Add(doktor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
           
        }

        // GET: doktor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.doktor == null)
            {
                return NotFound();
            }

            var doktor = await _context.doktor.FindAsync(id);
            if (doktor == null)
            {
                return NotFound();
            }
            ViewData["poliklinikid"] = new SelectList(_context.Set<poliklinik>(), "Id", "Id", doktor.poliklinikid);
            return View(doktor);
        }

        // POST: doktor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,tc,poliklinikid,sifre")] doktor doktor)
        {
            if (id != doktor.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doktor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!doktorExists(doktor.id))
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
            ViewData["poliklinikid"] = new SelectList(_context.Set<poliklinik>(), "Id", "Id", doktor.poliklinikid);
            return View(doktor);
        }

        // GET: doktor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.doktor == null)
            {
                return NotFound();
            }

            var doktor = await _context.doktor
                .Include(d => d.poliklinik)
                .FirstOrDefaultAsync(m => m.id == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // POST: doktor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.doktor == null)
            {
                return Problem("Entity set 'Hospital_WebsiteContext.doktor'  is null.");
            }
            var doktor = await _context.doktor.FindAsync(id);
            if (doktor != null)
            {
                _context.doktor.Remove(doktor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool doktorExists(int id)
        {
          return (_context.doktor?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}

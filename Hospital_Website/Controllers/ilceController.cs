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
    public class ilceController : Controller
    {
        private readonly Hospital_WebsiteContext _context;

        public ilceController(Hospital_WebsiteContext context)
        {
            _context = context;
        }

        // GET: ilce
        public async Task<IActionResult> Index()
        {
            var Hospital_WebsiteContext = _context.ilce.Include(i => i.il);
            return View(await Hospital_WebsiteContext.ToListAsync());
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

                _context.Add(ilce);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

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
                return Problem("Entity set 'Hospital_WebsiteContext.ilce'  is null.");
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

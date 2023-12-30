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
    public class hastaController : Controller
    {
        private readonly KocamanHastanesiContext _context;

        public hastaController(KocamanHastanesiContext context)
        {
            _context = context;
        }

        // GET: hasta
        public async Task<IActionResult> Index()
        {
              return _context.hasta != null ? 
                          View(await _context.hasta.ToListAsync()) :
                          Problem("Entity set 'KocamanHastanesiContext.hasta'  is null.");
        }

        // GET: hasta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.hasta == null)
            {
                return NotFound();
            }

            var hasta = await _context.hasta
                .FirstOrDefaultAsync(m => m.id == id);
            if (hasta == null)
            {
                return NotFound();
            }

            return View(hasta);
        }

        // GET: hasta/Create
        public IActionResult kayitOl()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
        public IActionResult Giris(hasta hasta)
        {
            var user = _context.hasta.FirstOrDefault(u => u.tc == hasta.tc && u.sifre == hasta.sifre);

            if (user != null)
            {
                HttpContext.Session.SetString("SessionUser", hasta.tc);
                HttpContext.Session.SetString("kullanıcıYetki", "Hasta");

                return RedirectToAction("Index", "Home");
            }

            TempData["hata"] = "Kullanıcı adı veya şifre hatalı";

            return RedirectToAction("login");
        }

        // POST: hasta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,tc,sifre")] hasta hasta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hasta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hasta);
        }

        // GET: hasta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.hasta == null)
            {
                return NotFound();
            }

            var hasta = await _context.hasta.FindAsync(id);
            if (hasta == null)
            {
                return NotFound();
            }
            return View(hasta);
        }

        // POST: hasta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,tc,sifre")] hasta hasta)
        {
            if (id != hasta.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hasta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!hastaExists(hasta.id))
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
            return View(hasta);
        }

        // GET: hasta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.hasta == null)
            {
                return NotFound();
            }

            var hasta = await _context.hasta
                .FirstOrDefaultAsync(m => m.id == id);
            if (hasta == null)
            {
                return NotFound();
            }

            return View(hasta);
        }

        // POST: hasta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.hasta == null)
            {
                return Problem("Entity set 'KocamanHastanesiContext.hasta'  is null.");
            }
            var hasta = await _context.hasta.FindAsync(id);
            if (hasta != null)
            {
                _context.hasta.Remove(hasta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool hastaExists(int id)
        {
          return (_context.hasta?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}

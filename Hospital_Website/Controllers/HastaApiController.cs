using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital_Website.Data;
using Hospital_Website.Models;

namespace Hospital_Website.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HastaApiController : ControllerBase
    {
        private readonly Hospital_WebsiteContext _context;

        public HastaApiController(Hospital_WebsiteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<hasta>>> GetHastalar()
        {
            var hastalar = await _context.hasta.ToListAsync();
            return Ok(hastalar);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<hasta>> GetHastaById(int id)
        {
            var hasta = await _context.hasta.FindAsync(id);

            if (hasta == null)
            {
                return NotFound();
            }

            return Ok(hasta);
        }

        [HttpPost]
        public async Task<ActionResult<hasta>> CreateHasta([FromBody] hasta hasta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hasta);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetHastaById), new { id = hasta.id }, hasta);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHasta(int id, [FromBody] hasta hasta)
        {
            if (id != hasta.id)
            {
                return BadRequest();
            }

            _context.Entry(hasta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HastaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHasta(int id)
        {
            var hasta = await _context.hasta.FindAsync(id);
            if (hasta == null)
            {
                return NotFound();
            }

            _context.hasta.Remove(hasta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HastaExists(int id)
        {
            return _context.hasta.Any(e => e.id == id);
        }
    }
}

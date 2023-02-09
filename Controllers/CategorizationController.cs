using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PindexBackend.Models;

namespace PindexBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorizationController : ControllerBase
    {
        private readonly PindexContext _context;

        public CategorizationController(PindexContext context)
        {
            _context = context;
        }

        // GET: api/Categorization
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorization>>> GetCategorization()
        {
          if (_context.Categorization == null)
          {
              return NotFound();
          }
            return await _context.Categorization.ToListAsync();
        }

        // GET: api/Categorization/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categorization>> GetCategorization(int id)
        {
          if (_context.Categorization == null)
          {
              return NotFound();
          }
            var categorization = await _context.Categorization.FindAsync(id);

            if (categorization == null)
            {
                return NotFound();
            }

            return categorization;
        }

        // PUT: api/Categorization/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorization(int id, Categorization categorization)
        {
            if (id != categorization.CategorizationId)
            {
                return BadRequest();
            }

            _context.Entry(categorization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorizationExists(id))
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

        // POST: api/Categorization
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Categorization>> PostCategorization(Categorization categorization)
        {
          if (_context.Categorization == null)
          {
              return Problem("Entity set 'PindexContext.Categorization'  is null.");
          }
            _context.Categorization.Add(categorization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorization", new { id = categorization.CategorizationId }, categorization);
        }

        // DELETE: api/Categorization/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorization(int id)
        {
            if (_context.Categorization == null)
            {
                return NotFound();
            }
            var categorization = await _context.Categorization.FindAsync(id);
            if (categorization == null)
            {
                return NotFound();
            }

            _context.Categorization.Remove(categorization);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategorizationExists(int id)
        {
            return (_context.Categorization?.Any(e => e.CategorizationId == id)).GetValueOrDefault();
        }
    }
}

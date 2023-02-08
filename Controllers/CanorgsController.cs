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
    public class CanorgsController : ControllerBase
    {
        private readonly PindexContext _context;

        public CanorgsController(PindexContext context)
        {
            _context = context;
        }

        // GET: api/Canorgs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Canorg>>> GetCanorgs()
        {
          if (_context.Canorgs == null)
          {
              return NotFound();
          }
            return await _context.Canorgs.ToListAsync();
        }

        // GET: api/Canorgs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Canorg>> GetCanorg(int id)
        {
          if (_context.Canorgs == null)
          {
              return NotFound();
          }
            var canorg = await _context.Canorgs.FindAsync(id);

            if (canorg == null)
            {
                return NotFound();
            }

            return canorg;
        }

        // PUT: api/Canorgs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCanorg(int id, Canorg canorg)
        {
            if (id != canorg.CanorgId)
            {
                return BadRequest();
            }

            _context.Entry(canorg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CanorgExists(id))
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

        // POST: api/Canorgs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Canorg>> PostCanorg(Canorg canorg)
        {
          if (_context.Canorgs == null)
          {
              return Problem("Entity set 'PindexContext.Canorgs'  is null.");
          }
            _context.Canorgs.Add(canorg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCanorg", new { id = canorg.CanorgId }, canorg);
        }

        // DELETE: api/Canorgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCanorg(int id)
        {
            if (_context.Canorgs == null)
            {
                return NotFound();
            }
            var canorg = await _context.Canorgs.FindAsync(id);
            if (canorg == null)
            {
                return NotFound();
            }

            _context.Canorgs.Remove(canorg);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CanorgExists(int id)
        {
            return (_context.Canorgs?.Any(e => e.CanorgId == id)).GetValueOrDefault();
        }
    }
}

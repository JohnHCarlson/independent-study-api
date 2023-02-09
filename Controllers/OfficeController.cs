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
    public class OfficeController : ControllerBase
    {
        private readonly PindexContext _context;

        public OfficeController(PindexContext context)
        {
            _context = context;
        }

        // GET: api/Office
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Office>>> GetOffice()
        {
          if (_context.Office == null)
          {
              return NotFound();
          }
            return await _context.Office.ToListAsync();
        }

        // GET: api/Office/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Office>> GetOffice(int id)
        {
          if (_context.Office == null)
          {
              return NotFound();
          }
            var office = await _context.Office.FindAsync(id);

            if (office == null)
            {
                return NotFound();
            }

            return office;
        }

        // PUT: api/Office/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffice(int id, Office office)
        {
            if (id != office.OfficeId)
            {
                return BadRequest();
            }

            _context.Entry(office).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeExists(id))
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

        // POST: api/Office
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Office>> PostOffice(Office office)
        {
          if (_context.Office == null)
          {
              return Problem("Entity set 'PindexContext.Office'  is null.");
          }
            _context.Office.Add(office);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OfficeExists(office.OfficeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOffice", new { id = office.OfficeId }, office);
        }

        // DELETE: api/Office/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffice(int id)
        {
            if (_context.Office == null)
            {
                return NotFound();
            }
            var office = await _context.Office.FindAsync(id);
            if (office == null)
            {
                return NotFound();
            }

            _context.Office.Remove(office);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfficeExists(int id)
        {
            return (_context.Office?.Any(e => e.OfficeId == id)).GetValueOrDefault();
        }
    }
}

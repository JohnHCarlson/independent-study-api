using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PindexBackend.Models;

namespace PindexBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly PindexContext _context;

        public ItemController(PindexContext context)
        {
            _context = context;
        }

        // GET: api/Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems(
            [FromQuery] string[] candidates,
            [FromQuery] string[] offices,
            [FromQuery] string[] locations,
            [FromQuery] string[] parties,
            [FromQuery] string[] issues,
            [FromQuery] string[] categorizations)
        {
            var itemsQuery = _context.Items
                .Include(i => i.Canorgs)
                .Include(i => i.Offices)
                .Include(i => i.Locations)
                .Include(i => i.Parties)
                .Include(i => i.Issues)
                .Include(i => i.Categorizations).AsQueryable();

            if (candidates != null && candidates.Length > 0) {
                itemsQuery = itemsQuery.Where(i => i.Canorgs.Any(co => candidates.Contains(co.Name)));
            }

            if (offices != null && offices.Length > 0) {
                itemsQuery = itemsQuery.Where(i => i.Offices.Any(of => offices.Contains(of.Name)));
            }

            if (locations != null && offices.Length > 0) {
                itemsQuery = itemsQuery.Where(i => i.Locations.Any(lo => offices.Contains(lo.Name)));
            }

            if (parties != null && parties.Length > 0) {
                itemsQuery = itemsQuery.Where(i => i.Parties.Any(pa => parties.Contains(pa.Name)));
            }

            if (issues != null && issues.Length > 0) {
                itemsQuery = itemsQuery.Where(i => i.Issues.Any(iu => issues.Contains(iu.Name)));
            }

            if (categorizations != null && categorizations.Length > 0) {
                itemsQuery = itemsQuery.Where(i => i.Categorizations.Any(ca => categorizations.Contains(ca.Name)));
            }

            var items = await itemsQuery.ToListAsync();
            return Ok(items);
        }

        // GET: api/Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
          if (_context.Items == null)
          {
              return NotFound();
          }
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/Item/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/Item
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
          if (_context.Items == null)
          {
              return Problem("Entity set 'PindexContext.Items'  is null.");
          }
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.ItemId }, item);
        }

        // DELETE: api/Item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            if (_context.Items == null)
            {
                return NotFound();
            }
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(int id)
        {
            return (_context.Items?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
    }
}

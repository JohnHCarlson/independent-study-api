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
    public class IssueController : ControllerBase
    {
        private readonly PindexContext _context;

        public IssueController(PindexContext context)
        {
            _context = context;
        }

        // GET: api/Issue
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Issue>>> GetIssue()
        {
          if (_context.Issue == null)
          {
              return NotFound();
          }
            return await _context.Issue.ToListAsync();
        }

        // GET: api/Issue/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Issue>> GetIssue(int id)
        {
          if (_context.Issue == null)
          {
              return NotFound();
          }
            var issue = await _context.Issue.FindAsync(id);

            if (issue == null)
            {
                return NotFound();
            }

            return issue;
        }

        // PUT: api/Issue/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIssue(int id, Issue issue)
        {
            if (id != issue.IssueId)
            {
                return BadRequest();
            }

            _context.Entry(issue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssueExists(id))
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

        // POST: api/Issue
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Issue>> PostIssue(Issue issue)
        {
          if (_context.Issue == null)
          {
              return Problem("Entity set 'PindexContext.Issue'  is null.");
          }
            _context.Issue.Add(issue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIssue", new { id = issue.IssueId }, issue);
        }

        // DELETE: api/Issue/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIssue(int id)
        {
            if (_context.Issue == null)
            {
                return NotFound();
            }
            var issue = await _context.Issue.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }

            _context.Issue.Remove(issue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IssueExists(int id)
        {
            return (_context.Issue?.Any(e => e.IssueId == id)).GetValueOrDefault();
        }
    }
}

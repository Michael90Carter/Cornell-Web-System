using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cornell_WebAPI.Data;
using Cornell_WebAPI.Models;

namespace Cornell_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumeratorController : ControllerBase
    {
        private readonly Cornell_WebAPI_DbContext _context;

        public EnumeratorController(Cornell_WebAPI_DbContext context)
        {
            _context = context;
        }

        // GET: api/Enumerator
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enumeratorsdetails>>> GetEnumeratorsdetails()
        {
          if (_context.Enumeratorsdetails == null)
          {
              return NotFound();
          }
            return await _context.Enumeratorsdetails.ToListAsync();
        }

        // GET: api/Enumerator/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enumeratorsdetails>> GetEnumeratorsdetails(int id)
        {
          if (_context.Enumeratorsdetails == null)
          {
              return NotFound();
          }
            var enumeratorsdetails = await _context.Enumeratorsdetails.FindAsync(id);

            if (enumeratorsdetails == null)
            {
                return NotFound();
            }

            return enumeratorsdetails;
        }

        // PUT: api/Enumerator/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnumeratorsdetails(int id, Enumeratorsdetails enumeratorsdetails)
        {
            if (id != enumeratorsdetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(enumeratorsdetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnumeratorsdetailsExists(id))
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

        // POST: api/Enumerator
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Enumeratorsdetails>> PostEnumeratorsdetails(Enumeratorsdetails enumeratorsdetails)
        {
          if (_context.Enumeratorsdetails == null)
          {
              return Problem("Entity set 'Cornell_WebAPI_DbContext.Enumeratorsdetails'  is null.");
          }
            _context.Enumeratorsdetails.Add(enumeratorsdetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnumeratorsdetails", new { id = enumeratorsdetails.Id }, enumeratorsdetails);
        }

        // DELETE: api/Enumerator/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnumeratorsdetails(int id)
        {
            if (_context.Enumeratorsdetails == null)
            {
                return NotFound();
            }
            var enumeratorsdetails = await _context.Enumeratorsdetails.FindAsync(id);
            if (enumeratorsdetails == null)
            {
                return NotFound();
            }

            _context.Enumeratorsdetails.Remove(enumeratorsdetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnumeratorsdetailsExists(int id)
        {
            return (_context.Enumeratorsdetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

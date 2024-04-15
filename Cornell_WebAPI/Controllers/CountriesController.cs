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
    public class CountriesController : ControllerBase
    {
        private readonly Cornell_WebAPI_DbContext _context;

        public CountriesController(Cornell_WebAPI_DbContext context)
        {
            _context = context;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Countriesdetails>>> GetCountriesdetails()
        {
          if (_context.Countriesdetails == null)
          {
              return NotFound();
          }
            return await _context.Countriesdetails.ToListAsync();
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Countriesdetails>> GetCountriesdetails(int id)
        {
          if (_context.Countriesdetails == null)
          {
              return NotFound();
          }
            var countriesdetails = await _context.Countriesdetails.FindAsync(id);

            if (countriesdetails == null)
            {
                return NotFound();
            }

            return countriesdetails;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountriesdetails(int id, Countriesdetails countriesdetails)
        {
            if (id != countriesdetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(countriesdetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountriesdetailsExists(id))
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

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Countriesdetails>> PostCountriesdetails(Countriesdetails countriesdetails)
        {
          if (_context.Countriesdetails == null)
          {
              return Problem("Entity set 'Cornell_WebAPI_DbContext.Countriesdetails'  is null.");
          }
            _context.Countriesdetails.Add(countriesdetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountriesdetails", new { id = countriesdetails.Id }, countriesdetails);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountriesdetails(int id)
        {
            if (_context.Countriesdetails == null)
            {
                return NotFound();
            }
            var countriesdetails = await _context.Countriesdetails.FindAsync(id);
            if (countriesdetails == null)
            {
                return NotFound();
            }

            _context.Countriesdetails.Remove(countriesdetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountriesdetailsExists(int id)
        {
            return (_context.Countriesdetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

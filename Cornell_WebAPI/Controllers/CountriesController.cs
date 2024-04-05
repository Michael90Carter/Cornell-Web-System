using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cornell_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Cornell_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {

        private readonly CornellContext _context;

        public CountriesController(CornellContext context)
        {
            _context = context;
        }

        // GET: api/Countriesdetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Countriesdetails>>> GetCountriesdetails()
        {
            if (_context.Countriesdetails == null)
            {
                return NotFound();
            }
            return await _context.Countriesdetails.ToListAsync();
        }

        // GET: api/Schoolsdetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Countriesdetails>> GetCountrydetail(int id)
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

        // PUT: api/Schoolsdetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchoolsdetails(int id, Countriesdetails countriesdetails)
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
                if (!CountriesdetailExists(id))
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

        // POST: api/Schoolsdetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Countriesdetails>> PostCountriesdetaila(Countriesdetails countriesdetails)
        {
            if (_context.Countriesdetails == null)
            {
                return Problem("Entity set 'StcharleslwangadbContext.Schoolsdetails'  is null.");
            }
            _context.Countriesdetails.Add(countriesdetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountriesdetails", new { id = countriesdetails.Id }, countriesdetails);
        }

        // DELETE: api/Schoolsdetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountriesdetails(int id)
        {
            if (_context.Countriesdetails == null)
            {
                return NotFound();
            }
            var schoolsdetails = await _context.Countriesdetails.FindAsync(id);
            if (schoolsdetails == null)
            {
                return NotFound();
            }

            _context.Countriesdetails.Remove(schoolsdetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountriesdetailExists(int id)
        {
            return (_context.Countriesdetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}


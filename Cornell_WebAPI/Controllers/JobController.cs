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
    public class JobController : ControllerBase
    {
        private readonly Cornell_WebAPI_DbContext _context;

        public JobController(Cornell_WebAPI_DbContext context)
        {
            _context = context;
        }

        // GET: api/Job
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jobdetails>>> GetJobdetails()
        {
          if (_context.Jobdetails == null)
          {
              return NotFound();
          }
            return await _context.Jobdetails.ToListAsync();
        }

        // GET: api/Job/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jobdetails>> GetJobdetails(int id)
        {
          if (_context.Jobdetails == null)
          {
              return NotFound();
          }
            var jobdetails = await _context.Jobdetails.FindAsync(id);

            if (jobdetails == null)
            {
                return NotFound();
            }

            return jobdetails;
        }

        // PUT: api/Job/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobdetails(int id, Jobdetails jobdetails)
        {
            if (id != jobdetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobdetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobdetailsExists(id))
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

        // POST: api/Job
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jobdetails>> PostJobdetails(Jobdetails jobdetails)
        {
          if (_context.Jobdetails == null)
          {
              return Problem("Entity set 'Cornell_WebAPI_DbContext.Jobdetails'  is null.");
          }
            _context.Jobdetails.Add(jobdetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobdetails", new { id = jobdetails.Id }, jobdetails);
        }

        // DELETE: api/Job/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobdetails(int id)
        {
            if (_context.Jobdetails == null)
            {
                return NotFound();
            }
            var jobdetails = await _context.Jobdetails.FindAsync(id);
            if (jobdetails == null)
            {
                return NotFound();
            }

            _context.Jobdetails.Remove(jobdetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobdetailsExists(int id)
        {
            return (_context.Jobdetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

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
    public class EmployerController : ControllerBase
    {
        private readonly Cornell_WebAPI_DbContext _context;

        public EmployerController(Cornell_WebAPI_DbContext context)
        {
            _context = context;
        }

        // GET: api/Employer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employerdetails>>> GetEmployerdetails()
        {
          if (_context.Employerdetails == null)
          {
              return NotFound();
          }
            return await _context.Employerdetails.ToListAsync();
        }

        // GET: api/Employer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employerdetails>> GetEmployerdetails(int id)
        {
          if (_context.Employerdetails == null)
          {
              return NotFound();
          }
            var employerdetails = await _context.Employerdetails.FindAsync(id);

            if (employerdetails == null)
            {
                return NotFound();
            }

            return employerdetails;
        }

        // PUT: api/Employer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployerdetails(int id, Employerdetails employerdetails)
        {
            if (id != employerdetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(employerdetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployerdetailsExists(id))
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

        // POST: api/Employer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employerdetails>> PostEmployerdetails(Employerdetails employerdetails)
        {
          if (_context.Employerdetails == null)
          {
              return Problem("Entity set 'Cornell_WebAPI_DbContext.Employerdetails'  is null.");
          }
            _context.Employerdetails.Add(employerdetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployerdetails", new { id = employerdetails.Id }, employerdetails);
        }

        // DELETE: api/Employer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployerdetails(int id)
        {
            if (_context.Employerdetails == null)
            {
                return NotFound();
            }
            var employerdetails = await _context.Employerdetails.FindAsync(id);
            if (employerdetails == null)
            {
                return NotFound();
            }

            _context.Employerdetails.Remove(employerdetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployerdetailsExists(int id)
        {
            return (_context.Employerdetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

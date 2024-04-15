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
    public class ClientController : ControllerBase
    {
        private readonly Cornell_WebAPI_DbContext _context;

        public ClientController(Cornell_WebAPI_DbContext context)
        {
            _context = context;
        }

        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientdetails>>> GetClientdetails()
        {
          if (_context.Clientdetails == null)
          {
              return NotFound();
          }
            return await _context.Clientdetails.ToListAsync();
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientdetails>> GetClientdetails(int id)
        {
          if (_context.Clientdetails == null)
          {
              return NotFound();
          }
            var clientdetails = await _context.Clientdetails.FindAsync(id);

            if (clientdetails == null)
            {
                return NotFound();
            }

            return clientdetails;
        }

        // PUT: api/Client/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientdetails(int id, Clientdetails clientdetails)
        {
            if (id != clientdetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientdetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientdetailsExists(id))
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

        // POST: api/Client
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clientdetails>> PostClientdetails(Clientdetails clientdetails)
        {
          if (_context.Clientdetails == null)
          {
              return Problem("Entity set 'Cornell_WebAPI_DbContext.Clientdetails'  is null.");
          }
            _context.Clientdetails.Add(clientdetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientdetails", new { id = clientdetails.Id }, clientdetails);
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientdetails(int id)
        {
            if (_context.Clientdetails == null)
            {
                return NotFound();
            }
            var clientdetails = await _context.Clientdetails.FindAsync(id);
            if (clientdetails == null)
            {
                return NotFound();
            }

            _context.Clientdetails.Remove(clientdetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientdetailsExists(int id)
        {
            return (_context.Clientdetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

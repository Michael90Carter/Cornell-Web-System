using Cornell_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cornell_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {

        private readonly CornellDbContext _context;

        public ClientsController(CornellDbContext context)
        {
            _context = context;
        }

        // GET: api/Clientdetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientdetails>>> GetClientdetails()
        {
            if (_context.Clientdetails == null)
            {
                return NotFound();
            }
            return await _context.Clientdetails.ToListAsync();
        }

        // GET: api/Schoolsdetails/5
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

        // PUT: api/Schoolsdetails/5
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
                if (!ClientdetailExists(id))
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
        public async Task<ActionResult<Clientdetails>> PostClientdetails(Clientdetails clientdetails)
        {
            if (_context.Clientdetails == null)
            {
                return Problem("Entity set 'CornellDbContext.Clientdetails'  is null.");
            }
            _context.Clientdetails.Add(clientdetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientdetails", new { id = clientdetails.Id }, clientdetails);
        }

        // DELETE: api/Schoolsdetails/5
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

        private bool ClientdetailExists(int id)
        {
            return (_context.Clientdetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

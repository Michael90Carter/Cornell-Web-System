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
    public class PlacementController : ControllerBase
    {
        private readonly Cornell_WebAPI_DbContext _context;

        public PlacementController(Cornell_WebAPI_DbContext context)
        {
            _context = context;
        }

        // GET: api/Placement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Placementdetails>>> GetPlacementdetails()
        {
          if (_context.Placementdetails == null)
          {
              return NotFound();
          }
            return await _context.Placementdetails.ToListAsync();
        }

        // GET: api/Placement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Placementdetails>> GetPlacementdetails(int id)
        {
          if (_context.Placementdetails == null)
          {
              return NotFound();
          }
            var placementdetails = await _context.Placementdetails.FindAsync(id);

            if (placementdetails == null)
            {
                return NotFound();
            }

            return placementdetails;
        }

        // PUT: api/Placement/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlacementdetails(int id, Placementdetails placementdetails)
        {
            if (id != placementdetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(placementdetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlacementdetailsExists(id))
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

        // POST: api/Placement
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Placementdetails>> PostPlacementdetails(Placementdetails placementdetails)
        {
          if (_context.Placementdetails == null)
          {
              return Problem("Entity set 'Cornell_WebAPI_DbContext.Placementdetails'  is null.");
          }
            _context.Placementdetails.Add(placementdetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlacementdetails", new { id = placementdetails.Id }, placementdetails);
        }

        // DELETE: api/Placement/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlacementdetails(int id)
        {
            if (_context.Placementdetails == null)
            {
                return NotFound();
            }
            var placementdetails = await _context.Placementdetails.FindAsync(id);
            if (placementdetails == null)
            {
                return NotFound();
            }

            _context.Placementdetails.Remove(placementdetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlacementdetailsExists(int id)
        {
            return (_context.Placementdetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

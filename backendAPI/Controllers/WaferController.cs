using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backendAPI.Models;

namespace backendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaferController : ControllerBase
    {
        private readonly WaferContext _context;

        public WaferController(WaferContext context)
        {
            _context = context;
        }

        // GET: api/Wafer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wafer>>> GetWafers()
        {
            return await _context.Wafers.ToListAsync();
        }

        // GET: api/Wafer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wafer>> GetWafer(int id)
        {
            var wafer = await _context.Wafers.FindAsync(id);

            if (wafer == null)
            {
                return NotFound();
            }

            return wafer;
        }

        // PUT: api/Wafer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWafer(int id, Wafer wafer)
        {
            if (id != wafer.Id)
            {
                return BadRequest();
            }

            _context.Entry(wafer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaferExists(id))
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

        // POST: api/Wafer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Wafer>> PostWafer(Wafer wafer)
        {
            _context.Wafers.Add(wafer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWafer", new { id = wafer.Id }, wafer);
        }

        // DELETE: api/Wafer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWafer(int id)
        {
            var wafer = await _context.Wafers.FindAsync(id);
            if (wafer == null)
            {
                return NotFound();
            }

            _context.Wafers.Remove(wafer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WaferExists(int id)
        {
            return _context.Wafers.Any(e => e.Id == id);
        }
    }
}

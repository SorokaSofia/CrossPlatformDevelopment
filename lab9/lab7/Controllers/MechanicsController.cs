using Microsoft.AspNetCore.Http;
using Lab7.Data;
using Lab7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MechanicsController : ControllerBase
    {
        private readonly DataContext _context;

        public MechanicsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mechanic>>> GetMechanics()
        {
            return await _context.Mechanics.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mechanic>> GetMechanic(int id)
        {
            var mechanic = await _context.Mechanics.FindAsync(id);
            if (mechanic == null)
            {
                return NotFound();
            }

            return mechanic;
        }

        [HttpPost]
        public async Task<ActionResult<Mechanic>> CreateMechanic(Mechanic mechanic)
        {
            _context.Mechanics.Add(mechanic);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMechanic), new { id = mechanic.MechanicId }, mechanic);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMechanic(int id, Mechanic mechanic)
        {
            if (id != mechanic.MechanicId)
            {
                return BadRequest();
            }

            _context.Entry(mechanic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Mechanics.Any(e => e.MechanicId == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMechanic(int id)
        {
            var mechanic = await _context.Mechanics.FindAsync(id);
            if (mechanic == null)
            {
                return NotFound();
            }

            _context.Mechanics.Remove(mechanic);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

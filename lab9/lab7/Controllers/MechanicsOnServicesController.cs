using Microsoft.AspNetCore.Http;
using Lab7.Data;
using Lab7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MechanicsOnServicesController : ControllerBase
    {
        private readonly DataContext _context;

        public MechanicsOnServicesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MechanicsOnService>>> GetAllMechanicsOnServices()
        {
            return await _context.MechanicsOnServices.Include(mos => mos.Mechanic).Include(mos => mos.ServiceBooking).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MechanicsOnService>> GetMechanicsOnServiceById(int id)
        {
            var mechanicsOnService = await _context.MechanicsOnServices.Include(mos => mos.Mechanic)
                .Include(mos => mos.ServiceBooking).FirstOrDefaultAsync(mos => mos.Id == id);

            if (mechanicsOnService == null)
            {
                return NotFound();
            }

            return mechanicsOnService;
        }

        [HttpPost]
        public async Task<ActionResult<MechanicsOnService>> CreateMechanicsOnService(MechanicsOnService mechanicsOnService)
        {
            _context.MechanicsOnServices.Add(mechanicsOnService);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMechanicsOnServiceById), new { id = mechanicsOnService.Id }, mechanicsOnService);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMechanicsOnService(int id, MechanicsOnService mechanicsOnService)
        {
            if (id != mechanicsOnService.Id)
            {
                return BadRequest();
            }

            _context.Entry(mechanicsOnService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.MechanicsOnServices.Any(mos => mos.Id == id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMechanicsOnService(int id)
        {
            var mechanicsOnService = await _context.MechanicsOnServices.FindAsync(id);
            if (mechanicsOnService == null)
            {
                return NotFound();
            }

            _context.MechanicsOnServices.Remove(mechanicsOnService);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

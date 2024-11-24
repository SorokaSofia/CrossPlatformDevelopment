using Microsoft.AspNetCore.Http;
using Lab7.Data;
using Lab7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly DataContext _context;

        public ManufacturersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/manufacturers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetManufacturers()
        {
            return await _context.Manufacturers.ToListAsync();
        }

        // GET: api/manufacturers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Manufacturer>> GetManufacturer(string id)
        {
            var manufacturer = await _context.Manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            return manufacturer;
        }

        // POST: api/manufacturers
        [HttpPost]
        public async Task<ActionResult<Manufacturer>> CreateManufacturer(Manufacturer manufacturer)
        {
            _context.Manufacturers.Add(manufacturer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetManufacturer), new { id = manufacturer.ManufacturerCode }, manufacturer);
        }

        // PUT: api/manufacturers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateManufacturer(string id, Manufacturer manufacturer)
        {
            if (id != manufacturer.ManufacturerCode)
            {
                return BadRequest();
            }

            _context.Entry(manufacturer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManufacturerExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/manufacturers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufacturer(string id)
        {
            var manufacturer = await _context.Manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            _context.Manufacturers.Remove(manufacturer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManufacturerExists(string id)
        {
            return _context.Manufacturers.Any(e => e.ManufacturerCode == id);
        }
    }
}

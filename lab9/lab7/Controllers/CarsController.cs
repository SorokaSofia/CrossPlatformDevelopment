using Microsoft.AspNetCore.Http;
using Lab7.Data;
using Lab7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly DataContext _context;

        public CarsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllCars()
        {
            return await _context.Cars.Include(c => c.Model).Include(c => c.Customer).ToListAsync();
        }

        [HttpGet("{licenceNumber}")]
        public async Task<ActionResult<Car>> GetCarByLicenceNumber(string licenceNumber)
        {
            var car = await _context.Cars.Include(c => c.Model).Include(c => c.Customer)
                .FirstOrDefaultAsync(c => c.LicenceNumber == licenceNumber);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        [HttpPost]
        public async Task<ActionResult<Car>> CreateCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarByLicenceNumber), new { licenceNumber = car.LicenceNumber }, car);
        }

        [HttpPut("{licenceNumber}")]
        public async Task<IActionResult> UpdateCar(string licenceNumber, Car car)
        {
            if (licenceNumber != car.LicenceNumber)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Cars.Any(c => c.LicenceNumber == licenceNumber))
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

        [HttpDelete("{licenceNumber}")]
        public async Task<IActionResult> DeleteCar(string licenceNumber)
        {
            var car = await _context.Cars.FindAsync(licenceNumber);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

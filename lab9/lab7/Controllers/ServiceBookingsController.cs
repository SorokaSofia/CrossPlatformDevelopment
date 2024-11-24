using Microsoft.AspNetCore.Http;
using Lab7.Data;
using Lab7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceBookingsController : ControllerBase
    {
        private readonly DataContext _context;

        public ServiceBookingsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceBooking>>> GetAllServiceBookings()
        {
            return await _context.ServiceBookings.Include(sb => sb.Customer).Include(sb => sb.Car).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceBooking>> GetServiceBookingById(int id)
        {
            var serviceBooking = await _context.ServiceBookings.Include(sb => sb.Customer).Include(sb => sb.Car)
                .FirstOrDefaultAsync(sb => sb.SvcBookingId == id);

            if (serviceBooking == null)
            {
                return NotFound();
            }

            return serviceBooking;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceBooking>> CreateServiceBooking(ServiceBooking serviceBooking)
        {
            _context.ServiceBookings.Add(serviceBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServiceBookingById), new { id = serviceBooking.SvcBookingId }, serviceBooking);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServiceBooking(int id, ServiceBooking serviceBooking)
        {
            if (id != serviceBooking.SvcBookingId)
            {
                return BadRequest();
            }

            _context.Entry(serviceBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ServiceBookings.Any(sb => sb.SvcBookingId == id))
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
        public async Task<IActionResult> DeleteServiceBooking(int id)
        {
            var serviceBooking = await _context.ServiceBookings.FindAsync(id);
            if (serviceBooking == null)
            {
                return NotFound();
            }

            _context.ServiceBookings.Remove(serviceBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

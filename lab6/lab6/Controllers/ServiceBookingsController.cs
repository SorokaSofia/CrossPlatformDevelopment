using Lab6.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class ServiceBookingsController : Controller
{
    private readonly CarServiceCenterContext _context;

    public ServiceBookingsController(CarServiceCenterContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var serviceBookings = await _context.ServiceBookings
            .Include(sb => sb.Car)
            .Include(sb => sb.Customer)
            .ToListAsync();
        return View(serviceBookings);
    }

    public async Task<IActionResult> Details(int id)
    {
        var serviceBooking = await _context.ServiceBookings
            .Include(sb => sb.Car)
            .Include(sb => sb.Customer)
            .FirstOrDefaultAsync(sb => sb.Id == id);
        if (serviceBooking == null)
        {
            return NotFound();
        }
        return View(serviceBooking);
    }
}

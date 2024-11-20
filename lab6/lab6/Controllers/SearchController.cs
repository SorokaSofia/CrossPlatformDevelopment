using Lab6.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class SearchController : Controller
{
    private readonly CarServiceCenterContext _context;

    public SearchController(CarServiceCenterContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Results(string startValue, string endValue)
    {
        var results = await _context.ServiceBookings
            .Include(sb => sb.Car)
            .Include(sb => sb.Customer)
            .Where(sb => sb.LicenceNumber.CompareTo(startValue) >= 0 && sb.LicenceNumber.CompareTo(endValue) <= 0)
            .ToListAsync();

        return View(results);
    }
}

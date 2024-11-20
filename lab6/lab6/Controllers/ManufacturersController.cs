using Lab6.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class ManufacturersController : Controller
{
    private readonly CarServiceCenterContext _context;

    public ManufacturersController(CarServiceCenterContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var manufacturers = await _context.Manufacturers.ToListAsync();
        return View(manufacturers);
    }

    public async Task<IActionResult> Details(int id)
    {
        var manufacturer = await _context.Manufacturers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (manufacturer == null)
        {
            return NotFound();
        }
        return View(manufacturer);
    }
}

using Microsoft.AspNetCore.Http;
using Lab7.Data;
using Lab7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly DataContext _context;

        public ModelsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model>>> GetModels()
        {
            return await _context.Models.Include(m => m.Manufacturer).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Model>> GetModel(string id)
        {
            var model = await _context.Models.Include(m => m.Manufacturer).FirstOrDefaultAsync(m => m.ModelCode == id);
            if (model == null)
            {
                return NotFound();
            }
            return model;
        }

        [HttpPost]
        public async Task<ActionResult<Model>> CreateModel(Model model)
        {
            _context.Models.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetModel), new { id = model.ModelCode }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModel(string id, Model model)
        {
            if (id != model.ModelCode)
            {
                return BadRequest();
            }

            _context.Entry(model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Models.Any(e => e.ModelCode == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel(string id)
        {
            var model = await _context.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _context.Models.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

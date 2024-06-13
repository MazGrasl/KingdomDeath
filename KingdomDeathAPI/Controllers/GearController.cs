using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class GearController : ControllerBase
{
    private readonly AppDbContext _context;

    public GearController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Gear
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GearDTO>>> GetItems()
    {
        return (await _context.Gears.Include(gear => gear.GearTags).ThenInclude(geartag => geartag.Tag).Include(gear => gear.Costs).ToListAsync()).ConvertAll(GearMapper.toDTO);
    }

    // GET: api/Gear/5
    [HttpGet("{id}")]
    public async Task<ActionResult<GearDTO>> GetGear(int id)
    {
        var item = await _context.Gears.FindAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        return GearMapper.toDTO(item);
    }

    // POST: api/Gear
    [HttpPost]
    public async Task<ActionResult<GearDTO>> PostGear(GearDTO itemDTO)
    {
        var item = GearMapper.toGear(itemDTO);
        _context.Gears.Add(item);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetItem", new { id = item.Id }, GearMapper.toDTO(item));
    }

    // PUT: api/Gear/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGear(int id, GearDTO itemDTO)
    {
        if (id != itemDTO.Id)
        {
            return BadRequest();
        }

        _context.Entry(GearMapper.toGear(itemDTO)).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!GearExists(id))
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

    // DELETE: api/Gears/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGear(int id)
    {
        var item = await _context.Gears.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }

        _context.Gears.Remove(item);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool GearExists(int id)
    {
        return _context.Gears.Any(e => e.Id == id);
    }
}
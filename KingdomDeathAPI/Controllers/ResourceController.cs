using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class ResourceController : ControllerBase
{
    private readonly AppDbContext _context;

    public ResourceController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Resource
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ResourceDTO>>> GetItems()
    {
        return (await _context.Resources.Include(resource => resource.Costs).Include(resource => resource.ResourceTags).ThenInclude(resourceTags => resourceTags.Tag).ToListAsync()).ConvertAll(ResourceMapper.toDTO);
    }

    // GET: api/Resource/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ResourceDTO>> GetResource(int id)
    {
        var item = await _context.Resources.FindAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        return ResourceMapper.toDTO(item);
    }

    // POST: api/Resource
    [HttpPost]
    public async Task<ActionResult<ResourceDTO>> PostResource(ResourceDTO itemDTO)
    {
        var item = ResourceMapper.toResource(itemDTO);
        _context.Resources.Add(item);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetResource", new { id = item.Id }, ResourceMapper.toDTO(item));
    }

    // PUT: api/Resource/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutResource(int id, ResourceDTO itemDTO)
    {
        if (id != itemDTO.Id)
        {
            return BadRequest();
        }

        _context.Entry(ResourceMapper.toResource(itemDTO)).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ResourceExists(id))
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

    // DELETE: api/Resources/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteResource(int id)
    {
        var item = await _context.Resources.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }

        _context.Resources.Remove(item);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ResourceExists(int id)
    {
        return _context.Resources.Any(e => e.Id == id);
    }
}
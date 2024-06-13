using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
[EnableCors()]
public class TagsController : ControllerBase
{
    private readonly AppDbContext _context;

    public TagsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Tags
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TagDTO>>> GetTags()
    {
        return (await _context.Tags.ToListAsync()).ConvertAll(TagMapper.toDTO);
    }

    // GET: api/Tags/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TagDTO>> GetTag(int id)
    {
        var tag = await _context.Tags.FindAsync(id);

        if (tag == null)
        {
            return NotFound();
        }

        return TagMapper.toDTO(tag);
    }

    // POST: api/Tags
    [HttpPost]
    public async Task<ActionResult<TagDTO>> PostTag(TagDTO tagDTO)
    {
        var tag = TagMapper.toTag(tagDTO);
        _context.Tags.Add(tag);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTag", new { id = tag.Id }, TagMapper.toDTO(tag));
    }

    // PUT: api/Tags/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTag(int id, TagDTO tagDTO)
    {
        if (id != tagDTO.Id)
        {
            return BadRequest();
        }

        _context.Entry(TagMapper.toTag(tagDTO)).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TagExists(id))
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

    // DELETE: api/Tags/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTag(int id)
    {
        var tag = await _context.Tags.FindAsync(id);
        if (tag == null)
        {
            return NotFound();
        }

        _context.Tags.Remove(tag);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TagExists(int id)
    {
        return _context.Tags.Any(e => e.Id == id);
    }
}
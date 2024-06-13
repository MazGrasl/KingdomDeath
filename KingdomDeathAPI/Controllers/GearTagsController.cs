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
public class GearTagsController : ControllerBase
{
    private readonly AppDbContext _context;

    public GearTagsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/GearTags
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GearTag>>> GetAllGearTags()
    {
        return await _context.GearTags.ToListAsync();
    }

    // GET: api/GearTags/Item/3
    [HttpGet("Item/{id}")]
    public async Task<ActionResult<IEnumerable<Tag>>> GetGearTags(int id)
    {
        var geartags = await _context.GearTags.Include(geartag => geartag.Tag).Where(geartag => geartag.Gear.Id == id).ToListAsync();
        List<Tag> tags = geartags.ConvertAll(geartag => geartag.Tag);
        return tags;
    }

    // POST: api/GearTags
    [HttpPost]
    public async Task<ActionResult<GearTag>> PostGearTag(int gearId, int tagId)
    {
        var Gear = await _context.Gears.Include(g => g.GearTags).FirstOrDefaultAsync(g => g.Id == gearId);
        var Tag = await _context.Tags.FindAsync(tagId);
        if(Gear == null)
        {
            return BadRequest("Gear not found");
        }
        if(Tag == null)
        {
            return BadRequest("Tag not found");
        }
        var exists = await _context.GearTags.Where(geartag => geartag.GearId == gearId && geartag.TagId == tagId).AnyAsync();
        if(exists)
        {
            return Conflict();
        }
        GearTag geartag = new GearTag
        {
            GearId = gearId,
            Gear = Gear,
            TagId = tagId,
            Tag = Tag
        };
        Gear.GearTags.Add(geartag);
        await _context.SaveChangesAsync();

        return Created();
    }

    // DELETE: api/GearTags
    [HttpDelete]
    public async Task<ActionResult> DeleteGearTag(int gearId, int tagId)
    {
        var gearTag = await _context.GearTags.FindAsync(gearId, tagId);
        if(gearTag == null)
        {
            return NotFound();
        }
        _context.GearTags.Remove(gearTag);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
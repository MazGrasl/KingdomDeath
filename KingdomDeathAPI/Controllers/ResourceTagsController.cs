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
public class ResourceTagsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ResourceTagsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/ResourceTags
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ResourceTag>>> GetAllResourceTags()
    {
        return await _context.ResourceTags.ToListAsync();
    }

    // GET: api/ResourceTags/Item/3
    [HttpGet("Item/{id}")]
    public async Task<ActionResult<IEnumerable<Tag>>> GetResourceTags(int id)
    {
        var resourcetags = await _context.ResourceTags.Include(resourcetag => resourcetag.Tag).Where(resourcetag => resourcetag.Resource.Id == id).ToListAsync();
        List<Tag> tags = resourcetags.ConvertAll(resourcetag => resourcetag.Tag);
        return tags;
    }

    // POST: api/ResourceTags
    [HttpPost]
    public async Task<ActionResult<GearTag>> PostResourceTag(int resourceId, int tagId)
    {
        var Resource = await _context.Resources.Include(r => r.ResourceTags).FirstOrDefaultAsync(r => r.Id == resourceId);
        var Tag = await _context.Tags.FindAsync(tagId);
        if(Resource == null)
        {
            return BadRequest("Resource not found");
        }
        if(Tag == null)
        {
            return BadRequest("Tag not found");
        }
        var exists = await _context.ResourceTags.Where(resourcetag => resourcetag.ResourceId == resourceId && resourcetag.TagId == tagId).AnyAsync();
        if(exists)
        {
            return Conflict();
        }
        ResourceTag resourcetag = new ResourceTag
        {
            ResourceId = resourceId,
            Resource = Resource,
            TagId = tagId,
            Tag = Tag
        };
        Resource.ResourceTags.Add(resourcetag);
        await _context.SaveChangesAsync();

        return Created();
    }

    // DELETE: api/ResourceTags
    [HttpDelete]
    public async Task<ActionResult> DeleteResourceTag(int resourceId, int tagId)
    {
        var resourceTag = await _context.ResourceTags.FindAsync(resourceId, tagId);
        if(resourceTag == null)
        {
            return NotFound();
        }
        _context.ResourceTags.Remove(resourceTag);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
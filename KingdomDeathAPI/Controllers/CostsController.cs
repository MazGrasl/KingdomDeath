using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class CostsController : ControllerBase {
    private readonly AppDbContext _context;
    private readonly CostMapper costMapper;

    public CostsController(AppDbContext context) {
        _context = context;
        costMapper = new CostMapper(context);
    }

    // GET: api/Costs
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CostDTO>>> GetCosts()
    {
        return (await _context.Costs.ToListAsync()).ConvertAll(CostMapper.toDTO);
    }

    // GET: api/Costs/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CostDTO>> GetCost(int id)
    {
        var cost = await _context.Costs.FindAsync(id);
        if(cost == null)
        {
            return NotFound();
        }
        return CostMapper.toDTO(cost);
    }

    // GET: api/Costs/Item/2
    [HttpGet("Item/{id}")]
    public async Task<ActionResult<IEnumerable<CostDTO>>> GetCostForGear(int id)
    {
        return (await _context.Costs.Where(c => c.GearId == id).ToListAsync()).ConvertAll(CostMapper.toDTO);
    }

    // POST: api/Costs
    [HttpPost]
    public async Task<ActionResult<CostDTO>> AddCost(CostDTO costDTO)
    {
        Cost cost = costMapper.toCost(costDTO);
        _context.Costs.Add(cost);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCost", new { id = cost.Id }, CostMapper.toDTO(cost));
    }

    // PUT: api/Costs/5
    [HttpPut("{id}")]
    public async Task<ActionResult<CostDTO>> EditCost(int id, CostDTO costDTO)
    {
        if(id != costDTO.Id)
        {
            return BadRequest();
        }
        _context.Entry(costMapper.toCost(costDTO)).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch(DBConcurrencyException)
        {
            if(!CostExists(id))
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

    // DELETE: api/Costs/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCost(int id)
    {
        var cost = await _context.Costs.FindAsync(id);
        if(cost == null)
        {
            return NotFound();
        }
        _context.Costs.Remove(cost);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool CostExists(int id)
    {
        return _context.Costs.Any(c => c.Id == id);
    }
}
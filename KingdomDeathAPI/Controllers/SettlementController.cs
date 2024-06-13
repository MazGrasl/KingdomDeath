using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class SettlementController : ControllerBase {
    private readonly AppDbContext _context;

    public SettlementController(AppDbContext context) {
        _context = context;
    }

    // GET api/Settlement
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SettlementDTO>>> GetAllSettlements() {
        return (await _context.Settlements.Include(s => s.GearStorage).ThenInclude(g => g.Gear).Include(s => s.ResourceStorage).ThenInclude(r => r.Resource).ToListAsync()).ConvertAll(SettlementMapper.toDTO);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SettlementDTO>> GetSettlementById(int id) {
        var item = await _context.Settlements.FindAsync(id);
        if (item == null) {
            return NotFound();
        }
        return SettlementMapper.toDTO(item);
    }

    [HttpPost]
    public async Task<ActionResult<SettlementDTO>> AddSettlement(string name) {
        var item = new Settlement { Name = name };
        _context.Add(item);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetSettlementById", new { id = item.Id }, SettlementMapper.toDTO(item));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSettlement(int id, SettlementDTO itemDTO) {
        if (id != itemDTO.Id)
        {
            return BadRequest();
        }
        _context.Entry(SettlementMapper.toSettlement(itemDTO)).State = EntityState.Modified;
         try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SettlementExists(id))
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

    private bool SettlementExists(int id)
    {
        return _context.Settlements.Any(e => e.Id == id);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSettlement(int id) {
        _context.Remove(id);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost("addGear")]
    public async Task<ActionResult<SettlementGearStorageItemDTO>> AddGearToSettlement([FromBody] SettlementGearStorageItemDTO itemDTO) {
        var settlement = await _context.Settlements.Include(s => s.GearStorage).ThenInclude(g => g.Gear).FirstOrDefaultAsync(s => s.Id == itemDTO.SettlementId);
        if (settlement == null) {
            return BadRequest("Settlement not found");
        }
        var gearStorageItem = settlement.GearStorage.FirstOrDefault(e => e.GearId == itemDTO.GearId);
        if (gearStorageItem == null) {
            var gear = await _context.Gears.FindAsync(itemDTO.GearId);
            if(gear == null) {
                return BadRequest("Gear not found");
            }
            gearStorageItem = SettlementGearStorageItemMapper.toItem(itemDTO, gear);
            settlement.GearStorage.Add(gearStorageItem);
        } else {
            gearStorageItem.Amount += itemDTO.Amount;
        }
        await _context.SaveChangesAsync();
        Console.WriteLine("A:{0} S:{1} GID:{2} GN:{3}", gearStorageItem.Amount, gearStorageItem.SettlementId, gearStorageItem.GearId, gearStorageItem.Gear?.Name);
        return SettlementGearStorageItemMapper.toDTO(gearStorageItem);
    }

    [HttpPost("removeGear")]
    public async Task<ActionResult<SettlementGearStorageItemDTO>> RemoveGearFromSettlement([FromBody] SettlementGearStorageItemDTO itemDTO) {
        var settlement = await _context.Settlements.Include(s => s.GearStorage).ThenInclude(g => g.Gear).FirstOrDefaultAsync(s => s.Id == itemDTO.SettlementId);
        if(settlement == null) {
            return BadRequest("Settlement not found");
        }
        var gear = settlement.GearStorage.FirstOrDefault(e => e.GearId == itemDTO.GearId);
        if(gear == null) {
            return BadRequest("Settlement does not have that gear");
        }
        gear.Amount -= itemDTO.Amount;
        if(gear.Amount <= 0) {
            settlement.GearStorage.Remove(gear);
            gear.Amount = 0;
        }
        await _context.SaveChangesAsync();
        return SettlementGearStorageItemMapper.toDTO(gear);
    }

    [HttpPost("addResource")]
    public async Task<ActionResult<SettlementResourceStorageItemDTO>> AddResourceToSettlement([FromBody] SettlementResourceStorageItemDTO itemDTO) {
        var settlement = await _context.Settlements.Include(s => s.ResourceStorage).ThenInclude(r => r.Resource).FirstOrDefaultAsync(s => s.Id == itemDTO.SettlementId);
        if(settlement == null) {
            return BadRequest("Settlement not found");
        }
        var resourceStorageItem = settlement.ResourceStorage.FirstOrDefault(e => e.ResourceId == itemDTO.ResourceId);
        if(resourceStorageItem == null) {
            var resource = await _context.Resources.FindAsync(itemDTO.ResourceId);
            if(resource == null) {
                return BadRequest("Resource not found");
            }
            resourceStorageItem = SettlementResourceStorageItemMapper.toItem(itemDTO, resource);
            settlement.ResourceStorage.Add(resourceStorageItem);
        } else {
            resourceStorageItem.Amount += itemDTO.Amount;
        }
        await _context.SaveChangesAsync();
        return SettlementResourceStorageItemMapper.toDTO(resourceStorageItem);
    }

    [HttpPost("removeResource")]
    public async Task<ActionResult<SettlementResourceStorageItemDTO>> RemoveResourceFromSettlement([FromBody] SettlementResourceStorageItemDTO itemDTO) {
        var settlement = await _context.Settlements.Include(s => s.ResourceStorage).ThenInclude(r => r.Resource).FirstOrDefaultAsync(s => s.Id == itemDTO.SettlementId);
        if (settlement == null) {
            return BadRequest("Settlement not found");
        }
        var resource = settlement.ResourceStorage.FirstOrDefault(e => e.ResourceId == itemDTO.ResourceId);
        if(resource == null) {
            return BadRequest("Settlement does not have that resource");
        }
        resource.Amount -= itemDTO.Amount;
        if(resource.Amount <= 0) {
            settlement.ResourceStorage.Remove(resource);
            resource.Amount = 0;
        }
        await _context.SaveChangesAsync();
        return SettlementResourceStorageItemMapper.toDTO(resource);
    }
}
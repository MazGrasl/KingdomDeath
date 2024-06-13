using System.Text.Json;
using System.Text.Json.Serialization;

public static class GearMapper {
    public static Gear toGear(GearDTO gearDTO) {
        return new Gear {
            Id = gearDTO.Id,
            Name = gearDTO.Name,
            Category = gearDTO.Category,
            Expansion = gearDTO.Expansion,
        };
    }

    public static GearDTO toDTO(Gear gear) {
        return new GearDTO {
            Id = gear.Id,
            Name = gear.Name,
            Category = gear.Category,
            Expansion = gear.Expansion,
            Costs = gear.Costs.ToList().ConvertAll(CostMapper.toDTO),
            Tags = gear.GearTags.ToList().ConvertAll(t => TagMapper.toDTO(t.Tag)),
            Type = gear.Type,
        };
    }
}
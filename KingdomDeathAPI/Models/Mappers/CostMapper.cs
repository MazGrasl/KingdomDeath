public class CostMapper(AppDbContext context) {
    public static CostDTO toDTO(Cost cost) {
        return new CostDTO {
            Id = cost.Id ?? 0,
            Amount = cost.Amount,
            GearId = cost.GearId,
            ResourceId = cost.ResourceId,
            TagId = cost.TagId,
        };
    }

    public Cost toCost(CostDTO costDTO) {
        return new Cost {
            Id = costDTO.Id,
            Amount = costDTO.Amount,
            GearId = costDTO.GearId,
            Gear = context.Gears.FirstOrDefault(g => g.Id == costDTO.GearId),
            ResourceId = costDTO.ResourceId,
            Resource = context.Resources.FirstOrDefault(r => r.Id == costDTO.ResourceId),
            TagId = costDTO.TagId,
            Tag = context.Tags.FirstOrDefault(t => t.Id == costDTO.TagId),
        };
    }
}
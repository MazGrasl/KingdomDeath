using Swashbuckle.AspNetCore.Annotations;

public class Settlement {
    [SwaggerSchema(ReadOnly = true)]
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<SettlementGearStorageItem> GearStorage { get; set; } = [];
    public ICollection<SettlementResourceStorageItem> ResourceStorage { get; set; } = [];
}
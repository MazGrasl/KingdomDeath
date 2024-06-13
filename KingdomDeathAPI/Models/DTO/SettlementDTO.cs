public class SettlementDTO {
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public ICollection<SettlementGearStorageItemDTO> GearStorage { get; set; } = [];
    public ICollection<SettlementResourceStorageItemDTO> ResourceStorage { get; set; } = [];
}

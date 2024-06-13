public class SettlementResourceStorageItemDTO {
    public int SettlementId { get; set; }
    public int Amount { get; set; }
    public int ResourceId { get; set; }
    public string ResourceName { get; set; } = default!;
}

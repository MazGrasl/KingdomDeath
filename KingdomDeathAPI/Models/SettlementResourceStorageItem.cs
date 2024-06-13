public class SettlementResourceStorageItem {
    public int SettlementId { get; set; }
    public int Amount { get; set; }
    public int ResourceId { get; set; }
    public Settlement Settlement { get; set; } = default!;
    public Resource Resource { get; set; } = default!;
}
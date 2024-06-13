public class SettlementGearStorageItem {
    public int SettlementId { get; set; }
    public int Amount { get; set; }
    public int GearId { get; set; }
    public Settlement Settlement { get; set; } = null!;
    public Gear Gear { get; set; } = null!;
}
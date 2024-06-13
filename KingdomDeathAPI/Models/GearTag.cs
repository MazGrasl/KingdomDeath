public class GearTag {
    public int GearId { get; set; }
    public Gear Gear { get; set; } = default!;
    public int TagId { get; set; }
    public Tag Tag { get; set; } = default!;
}
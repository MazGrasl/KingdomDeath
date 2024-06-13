public class Gear : Item {
    public override string Type { get; } = "Gear";
    public ICollection<Cost> Costs { get; set; } = [];
    public ICollection<GearTag> GearTags { get; } = [];
}
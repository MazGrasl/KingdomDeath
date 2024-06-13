public class Resource : Item {
    public override string Type { get; } = "Resource";
    public List<Cost> Costs { get; } = [];
    public ICollection<ResourceTag> ResourceTags { get; } = null!;
}
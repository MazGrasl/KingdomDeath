using System.ComponentModel.DataAnnotations.Schema;

public class Cost {
    public int? Id { get; set; }
    public int GearId { get; set; }
    public Gear? Gear { get; set; } = null!;
    public int Amount { get; set; }
    public int? ResourceId { get; set; }
    public Resource? Resource { get; set; } = null!;
    public int? TagId { get; set; }
    public Tag? Tag { get; set; } = null!;
}

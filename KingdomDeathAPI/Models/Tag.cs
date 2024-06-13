using Swashbuckle.AspNetCore.Annotations;

public class Tag
{
    [SwaggerSchema(ReadOnly = true)]
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public List<Gear> Gears { get; } = [];
    public List<Resource> Resources { get; } = [];
}
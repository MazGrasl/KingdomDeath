using Swashbuckle.AspNetCore.Annotations;

public abstract class Item
{
    [SwaggerSchema(ReadOnly = true)]
    public int Id { get; set; }
    public required string Name { get; set; }
    public abstract string Type { get; }
    public string Category { get; set; } = default!;
    public string Expansion { get; set; } = default!;
    public List<Tag> Tags { get; set; } = [];
}
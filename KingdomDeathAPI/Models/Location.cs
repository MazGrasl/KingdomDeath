using Swashbuckle.AspNetCore.Annotations;

public class Location {
    [SwaggerSchema(ReadOnly = true)]
    public int Id { get; set; }
    public required string Name { get; set; }
}
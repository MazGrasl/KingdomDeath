public class ResourceDTO {
    public int Id {get; set;}
    public string Name {get; set;} = default!;
    public string Category {get; set;} = default!;
    public string Expansion {get; set;} = default!;
    public string Type {get; set;} = default!;
    public ICollection<TagDTO> Tags {get; set;} = [];
}
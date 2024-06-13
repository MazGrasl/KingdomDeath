public static class ResourceMapper {
    public static Resource toResource(ResourceDTO resourceDTO) {
        return new Resource {
            Id = resourceDTO.Id,
            Name = resourceDTO.Name,
            Category = resourceDTO.Category,
            Expansion = resourceDTO.Expansion
        };
    }

    public static ResourceDTO toDTO(Resource resource) {
        return new ResourceDTO {
            Id = resource.Id,
            Name = resource.Name,
            Category = resource.Category,
            Expansion = resource.Expansion,
            Tags = resource.ResourceTags.ToList().ConvertAll(t => TagMapper.toDTO(t.Tag)),
            Type = resource.Type,
        };
    }
}

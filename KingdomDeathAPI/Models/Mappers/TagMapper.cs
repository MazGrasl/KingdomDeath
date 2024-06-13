public static class TagMapper {
    public static Tag toTag(TagDTO tagDTO) {
        return new Tag {
            Id = tagDTO.Id,
            Name = tagDTO.Name,
        };
    }

    public static TagDTO toDTO(Tag tag) {
        return new TagDTO {
            Id = tag.Id,
            Name = tag.Name,
        };
    }
}
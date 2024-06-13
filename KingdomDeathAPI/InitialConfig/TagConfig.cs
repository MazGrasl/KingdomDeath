public static class TagConfig {
    public static string[] Keywords { get; } = [
        "Amber",
        "Ammunation",
        "Armor",
        "Arrow",
        "Axe",
        "Badge",
        "Balm",
        "Bone (Gear)",
        "Bone (Resource)",
        "Bow",
        "Cloth",
        "Club",
        "Consumable",
        "Dagger",
        "Feather",
        "Finesse",
        "Fish",
        "Flammable",
        "Flower",
        "Fragile",
        "Fur",
        "Gloomy",
        "Gormskin",
        "Grand",
        "Gun",
        "Heavy",
        "Herb",
        "Hide",
        "Instrument",
        "Iron",
        "Item",
        "Ivory",
        "Jewelry",
        "Katana",
        "Katar",
        "Knight",
        "Lantern",
        "Leather",
        "Mask",
        "Melee",
        "Metal",
        "Mineral",
        "Noisy",
        "Nuclear",
        "Order",
        "Organ",
        "Other",
        "Perfect",
        "Pickaxe",
        "Ranged",
        "Rawhide",
        "Scale",
        "Scimitar",
        "Scrap",
        "Scythe",
        "Set",
        "Shield",
        "Sickle",
        "Silk",
        "Soluble",
        "Spear",
        "Steel",
        "Stinky",
        "Stone",
        "Sword",
        "Symbol",
        "Tool",
        "Two-handed",
        "Vegetable",
        "Weapon",
        "Whip",
        "Resource",
        "Thrown",
        "Vermin"
    ];
    public static List<Tag> createTagList()
    {
        int currentTagId = 0;
        List<Tag> tags = Keywords.ToList().ConvertAll(name =>
        {
            Tag tag = new()
            {
                Id = ++currentTagId,
                Name = name
            };
            return tag;
        });
        return tags;
    }
}
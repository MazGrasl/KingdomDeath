public static class ResourceConfig {
        public static string[] BasicResources = [
        "???",
        "Broken Lantern",
        "Love Juice",
        "Lump of Atnas",
        "Monster Bone",
        "Monster Hide",
        "Monster Organ",
        "Perfect Bone",
        "Perfect Hide",
        "Perfect Organ",
        "Skull",
    ];
    public static string[] DKResources = [
        "Cabled Vein",
        "Dragon Iron",
        "Hardened Ribs",
        "Horn Fragment",
        "Husk",
        "King’s Claws",
        "King's Tongue",
        "Radioactive Dung",
        "Veined Wing",
    ];
    public static string[] DBKResources = [
        "Beetle Horn",
        "Century Fingernails",
        "Century Shell",
        "Compound Eye",
        "Elytra",
        "Scarab Shell",
        "Scarab Wing",
        "Underplate Fungus",
    ];
    public static string[] FKResources = [
        "Warbling Bloom",
        "Osseous Bloom",
        "Sighing Bloom",
        "Lantern Bloom",
        "Lantern Bud",
    ];
    public static string[] GormResources = [
        "Dense Bone",
        "Stout Vertebrae",
        "Stout Hide",
        "Mammoth Hand",
        "Jiggling Lard",
        "Milky Eye",
        "Meaty Rib",
        "Handed Skull",
        "Gorm Brain",
        "Stout Kidney",
        "Stout Heart",
        "Acid Gland",
    ];
    public static string[] PhoenixResources = [
        "Bird Beak",
        "Black Skull",
        "Hollow Wing Bones",
        "Muculent Droppings",
        "Phoenix Eye",
        "Phoenix Finger",
        "Phoenix Whisker",
        "Pustules",
        "Rainbow Droppings",
        "Shimmering Halo",
        "Small Feathers",
        "Small Hand Parasites",
        "Tail Feathers",
        "Wishbone",
    ];
    public static string[] ScreamingAntelopeResources = [
        "Beast Steak",
        "Bladder",
        "Large Flat Tooth",
        "Muscly Gums",
        "Pelt",
        "Screaming Brain",
        "Shank Bone",
        "Spiral Horn",
    ];
    public static string[] SpidiculesResources = [
        "Arachnid Heart",
        "Chitin",
        "Exoskeleton",
        "Eyeballs",
        "Large Appendage",
        "Serrated Fangs",
        "Small Appendages",
        "Spinnerets",
        "Stomach",
        "Thick Web Silk",
        "Unlaid Eggs",
        "Venom Sac",
    ];
    public static string[] SunstalkerResources = [
        "Black Lens",
        "Brain Root",
        "Cycloid Scales",
        "Fertility Tentacle",
        "Huge Sunteeth",
        "Inner Shadow Skin",
        "Prismatic Gills",
        "Shadow Ink Gland",
        "Shadow Tentacles",
        "Shark Tongue",
        "Small Sunteeth",
        "Stink Lung",
        "Sunshark Blubber",
        "Sunshark Bone",
        "Sunshark Fin",
    ];
    public static string[] WhiteLionResources = [
        "Curious Hand",
        "Eye of Cat",
        "Golden Whiskers",
        "Great Cat Bones",
        "Lion Claw",
        "Lion Tail",
        "Lion Testes",
        "Shimmering Mane",
        "Sinew",
        "White Fur",
    ];
    public static string[] CoreStrangeResources = [
        "Black Lichen",
        "Cocoon Membrane",
        "Elder Cat Teeth",
        "Fresh Acanthus",
        "Iron",
        "Lantern Tube",
        "Leather",
        "Perfect Crucible",
        "Phoenix Crest",
        "Legendary Horns",
        "Second Heart",
    ];
    public static string[] DBKStrangeResources = [
        "Preserved Caustic Dung",
        "Scell",
    ];
    public static string[] GormStrangeResources = [
        "Pure Bulb",
        "Active Thyroid",
        "Stomach Lining",
        "Gormite",
    ];
    public static string[] LGStrangeResources = [
        "Canopic Jar",
        "Old Blue Box",
        "Sarcophagus",
        "Silver Urn",
        "Triptych",
    ];
    public static string[] LTStrangeResources = [
        "Blistering Plasma Fruit",
        "Drifting Dream Fruit",
        "Jagged Marrow Fruit",
        "Lonely Fruit",
        "Porous Flesh Fruit",
    ];
    public static string[] SPStrangeResources = [
        "Web Silk",
        "Silken Nervous System",
    ];
    public static string[] MHStrangeResources = [
        "Crimson Vial",
        "Red Vial",
    ];
    public static string[] SlendermanStrangeResources = [
        "Crystal Sword Mold",
        "Dark Water",
    ];
    public static string[] SunstalkerStrangeResources = [
        "1,000 Year Sunspot",
        "3,000 Year Sunspot",
        "Bugfish",
        "Hagfish",
        "Jowls",
        "Salt",
        "Sunstones",
    ];
    public static string[] DKStrangeResources = [
        "Pituitary Gland",
        "Radiant Heart",
        "Shining Liver",
    ];
    public static string[] VerminResources = [
        "Crab Spider",
        "Cyclops Fly",
        "Hissing Cockroach",
        "Lonely Ant",
        "Nightmare Tick",
        "Sword Beetle"
    ];

    public static List<Resource> createResourceList()
    {
        int currentItemId = 0;
        string currentExpansion = "Core Game";
        List<Resource> resources = [
            .. ResourceConfig.BasicResources.ToList().ConvertAll(name => {
                Resource resource = new() {
                    Id = ++currentItemId,
                    Name = name,
                    Category = "Basic Resource",
                    Expansion = currentExpansion,
                };
                return resource;
            }),
            .. ResourceConfig.PhoenixResources.ToList().ConvertAll(name => {
                Resource resource = new() {
                    Id = ++currentItemId,
                    Name = name,
                    Category = "Phoenix Resource",
                    Expansion = currentExpansion,
                };
                return resource;
            }),
            .. ResourceConfig.ScreamingAntelopeResources.ToList().ConvertAll(name => {
                Resource resource = new() {
                    Id = ++currentItemId,
                    Name = name,
                    Category = "Screaming Antelope Resource",
                    Expansion = currentExpansion,
                };
                return resource;
            }),
            .. ResourceConfig.WhiteLionResources.ToList().ConvertAll(name => {
                Resource resource = new() {
                    Id = ++currentItemId,
                    Name = name,
                    Category = "White Lion Resource",
                    Expansion = currentExpansion,
                };
                return resource;
            }),
            .. ResourceConfig.CoreStrangeResources.ToList().ConvertAll(name => {
                Resource resource = new() {
                    Id = ++currentItemId,
                    Name = name,
                    Category = "Strange Resource",
                    Expansion = currentExpansion,
                };
                return resource;
            }),
        ];
        currentExpansion = "Dragon King Expansion";
        resources = [..resources,
            .. ResourceConfig.DKResources.ToList().ConvertAll(name => {
                Resource resource = new() {
                    Id = ++currentItemId,
                    Name = name,
                    Category = "Dragon King Resource",
                    Expansion = currentExpansion,
                };
                return resource;
            }),
            .. ResourceConfig.DKStrangeResources.ToList().ConvertAll(name => {
                Resource resource = new() {
                    Id = ++currentItemId,
                    Name = name,
                    Category = "Strange Resource",
                    Expansion = currentExpansion,
                };
                return resource;
            }),
        ];
        currentExpansion = "Dung Beetle Knight Expansion";
        resources = [..resources,
            .. ResourceConfig.DBKResources.ToList().ConvertAll(name => {
                Resource resource = new() {
                    Id = ++currentItemId,
                    Name = name,
                    Category = "Dung Beetle Knight Resource",
                    Expansion = currentExpansion,
                };
                return resource;
            }),
            .. ResourceConfig.DBKStrangeResources.ToList().ConvertAll(name => {
                Resource resource = new() {
                    Id = ++currentItemId,
                    Name = name,
                    Category = "Strange Resource",
                    Expansion = currentExpansion,
                };
                return resource;
            }),
        ];
        currentExpansion = "Flower Knight Expansion";
        resources = [..resources,
            .. ResourceConfig.FKResources.ToList().ConvertAll(name => {
                Resource resource = new() {
                    Id = ++currentItemId,
                    Name = name,
                    Category = "Flower Knight Resource",
                    Expansion = currentExpansion,
                    
                };
                return resource;
            })
        ];
        currentExpansion = "Gorm Expansion";
        resources = [..resources,
            .. ResourceConfig.GormResources.ToList().ConvertAll(name => {
                Resource resource = new() {
                    Id = ++currentItemId,
                    Name = name,
                    Category = "Gorm Resource",
                    Expansion = currentExpansion,
                };
                return resource;
            }),
            .. ResourceConfig.GormStrangeResources.ToList().ConvertAll(name => {
                Resource resource = new() {
                    Id = ++currentItemId,
                    Name = name,
                    Category = "Strange Resource",
                    Expansion = currentExpansion,
                };
                return resource;
            }),
        ];
        currentExpansion = "Lion God Expansion";
        resources = [..resources,
            .. ResourceConfig.LGStrangeResources.ToList().ConvertAll(name => {
                Resource resource = new() {
                    Id = ++currentItemId,
                    Name = name,
                    Category = "Strange Resource",
                    Expansion = currentExpansion,
                    
                };
                return resource;
            }),
        ];
        currentExpansion = "Lonely Tree Expansion";
        resources = [..resources,
            .. ResourceConfig.LTStrangeResources.ToList().ConvertAll(name => {
                Resource resource = new() {
                    Id = ++currentItemId,
                    Name = name,
                    Category = "Strange Resource",
                    Expansion = currentExpansion,
                    
                };
                return resource;
            })
        ];
        currentExpansion = "Manhunter Expansion";
        resources = [..resources,
            .. ResourceConfig.MHStrangeResources.ToList().ConvertAll(name => {
                Resource resource = new() {
                    Id = ++currentItemId,
                    Name = name,
                    Category = "Strange Resource",
                    Expansion = currentExpansion,
                    
                };
                return resource;
            }),
        ];
        currentExpansion = "Slenderman Expansion";
        resources = [..resources,
            .. ResourceConfig.SlendermanStrangeResources.ToList().ConvertAll(name => {
                Resource resource = new() {
                    Id = ++currentItemId,
                    Name = name,
                    Category = "Strange Resource",
                    Expansion = currentExpansion,
                    
                };
                return resource;
            }),
        ];
        currentExpansion = "Sunstalker Expansion";
        resources = [..resources,
            .. ResourceConfig.SunstalkerResources.ToList().ConvertAll(name => {
                Resource resource = new() {
                    Id = ++currentItemId,
                    Name = name,
                    Category = "Sunstalker Resource",
                    Expansion = currentExpansion,
                    
                };
                return resource;
            }),
            .. ResourceConfig.SunstalkerStrangeResources.ToList().ConvertAll(name => {
                Resource resource = new() {
                    Id = ++currentItemId,
                    Name = name,
                    Category = "Strange Resource",
                    Expansion = currentExpansion,
                    
                };
                return resource;
            }),
        ];
        currentExpansion = "Spidicules Expansion";
        resources = [..resources,
                    .. ResourceConfig.SpidiculesResources.ToList().ConvertAll(name => {
                Resource resource = new() {
                    Id = ++currentItemId,
                    Name = name,
                    Category = "Spidicules Resource",
                    Expansion = currentExpansion,
                    
                };
                return resource;
            }),
            .. ResourceConfig.SPStrangeResources.ToList().ConvertAll(name => {
                Resource resource = new() {
                    Id = ++currentItemId,
                    Name = name,
                    Category = "Strange Resource",
                    Expansion = currentExpansion,
                    
                };
                return resource;
            }),
        ];
        resources = [..resources,
            .. ResourceConfig.VerminResources.ToList().ConvertAll(name => {
                Resource resource = new() {
                    Id = ++currentItemId,
                    Name = name,
                    Category = "Vermin Resource",
                    Expansion = "Core Game",
                };
                return resource;
            })
        ];
        return resources;
    }
}
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KingdomDeathAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "KD");

            migrationBuilder.CreateTable(
                name: "Gears",
                schema: "KD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expansion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                schema: "KD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expansion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "KD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Costs",
                schema: "KD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GearId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: true),
                    TagId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Costs_Gears_GearId",
                        column: x => x.GearId,
                        principalSchema: "KD",
                        principalTable: "Gears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Costs_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalSchema: "KD",
                        principalTable: "Resources",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Costs_Tags_TagId",
                        column: x => x.TagId,
                        principalSchema: "KD",
                        principalTable: "Tags",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GearTag",
                schema: "KD",
                columns: table => new
                {
                    GearsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearTag", x => new { x.GearsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_GearTag_Gears_GearsId",
                        column: x => x.GearsId,
                        principalSchema: "KD",
                        principalTable: "Gears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GearTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalSchema: "KD",
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceTag",
                schema: "KD",
                columns: table => new
                {
                    ResourcesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTag", x => new { x.ResourcesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ResourceTag_Resources_ResourcesId",
                        column: x => x.ResourcesId,
                        principalSchema: "KD",
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalSchema: "KD",
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "KD",
                table: "Gears",
                columns: new[] { "Id", "Category", "Expansion", "Name" },
                values: new object[,]
                {
                    { 1, "Barber Surgeon", "Core Game", "Almanac" },
                    { 2, "Barber Surgeon", "Core Game", "Blue Charm" },
                    { 3, "Barber Surgeon", "Core Game", "Bug Trap" },
                    { 4, "Barber Surgeon", "Core Game", "First Aid Kit" },
                    { 5, "Barber Surgeon", "Core Game", "Green Charm" },
                    { 6, "Barber Surgeon", "Core Game", "Musk Bomb" },
                    { 7, "Barber Surgeon", "Core Game", "Red Charm" },
                    { 8, "Barber Surgeon", "Core Game", "Scavenger Kit" },
                    { 9, "Blacksmith", "Core Game", "Beacon Shield" },
                    { 10, "Blacksmith", "Core Game", "Dragon Slayer" },
                    { 11, "Blacksmith", "Core Game", "Lantern Cuirass" },
                    { 12, "Blacksmith", "Core Game", "Lantern Dagger" },
                    { 13, "Blacksmith", "Core Game", "Lantern Gauntlets" },
                    { 14, "Blacksmith", "Core Game", "Lantern Glaive" },
                    { 15, "Blacksmith", "Core Game", "Lantern Greaves" },
                    { 16, "Blacksmith", "Core Game", "Lantern Helm" },
                    { 17, "Blacksmith", "Core Game", "Lantern Mail" },
                    { 18, "Blacksmith", "Core Game", "Lantern Sword" },
                    { 19, "Blacksmith", "Core Game", "Perfect Slayer" },
                    { 20, "Blacksmith", "Core Game", "Polishing Lantern" },
                    { 21, "Blacksmith", "Core Game", "Ring Whip" },
                    { 22, "Blacksmith", "Core Game", "Scrap Shield" },
                    { 23, "Bone Smith", "Core Game", "Bone Axe" },
                    { 24, "Bone Smith", "Core Game", "Bone Blade" },
                    { 25, "Bone Smith", "Core Game", "Bone Club" },
                    { 26, "Bone Smith", "Core Game", "Bone Dagger" },
                    { 27, "Bone Smith", "Core Game", "Bone Darts" },
                    { 28, "Bone Smith", "Core Game", "Bone Pickaxe" },
                    { 29, "Bone Smith", "Core Game", "Bone Sickle" },
                    { 30, "Bone Smith", "Core Game", "Skull Helm" },
                    { 31, "Catarium", "Core Game", "Cat Eye Circlet" },
                    { 32, "Catarium", "Core Game", "Cat Fang Knife" },
                    { 33, "Catarium", "Core Game", "Cat Gut Bow" },
                    { 34, "Catarium", "Core Game", "Claw Head Arrow" },
                    { 35, "Catarium", "Core Game", "Frenzy Drink" },
                    { 36, "Catarium", "Core Game", "King Spear" },
                    { 37, "Catarium", "Core Game", "Lion Beast Katar" },
                    { 38, "Catarium", "Core Game", "Lion Headdress" },
                    { 39, "Catarium", "Core Game", "Lion Skin Cloak" },
                    { 40, "Catarium", "Core Game", "Whisker Harp" },
                    { 41, "Catarium", "Core Game", "White Lion Boots" },
                    { 42, "Catarium", "Core Game", "White Lion Coat" },
                    { 43, "Catarium", "Core Game", "White Lion Gauntlets" },
                    { 44, "Catarium", "Core Game", "White Lion Helm" },
                    { 45, "Catarium", "Core Game", "White Lion Skirt" },
                    { 46, "Exhausted Lantern Hoard", "Core Game", "Final Lantern" },
                    { 47, "Exhausted Lantern Hoard", "Core Game", "Oxidized Beacon Shield" },
                    { 48, "Exhausted Lantern Hoard", "Core Game", "Oxidized Lantern Dagger" },
                    { 49, "Exhausted Lantern Hoard", "Core Game", "Oxidized Lantern Glaive" },
                    { 50, "Exhausted Lantern Hoard", "Core Game", "Oxidized Lantern Helm" },
                    { 51, "Exhausted Lantern Hoard", "Core Game", "Oxidized Lantern Sword" },
                    { 52, "Exhausted Lantern Hoard", "Core Game", "Oxidized Ring Whip" },
                    { 53, "Exhausted Lantern Hoard", "Core Game", "Survivors' Lantern" },
                    { 54, "Leather Worker", "Core Game", "Hunter Whip" },
                    { 55, "Leather Worker", "Core Game", "Leather Boots" },
                    { 56, "Leather Worker", "Core Game", "Leather Bracers" },
                    { 57, "Leather Worker", "Core Game", "Leather Cuirass" },
                    { 58, "Leather Worker", "Core Game", "Leather Mask" },
                    { 59, "Leather Worker", "Core Game", "Leather Skirt" },
                    { 60, "Leather Worker", "Core Game", "Round Leather Shield" },
                    { 61, "Mask Maker", "Core Game", "Antelope Mask" },
                    { 62, "Mask Maker", "Core Game", "Death Mask" },
                    { 63, "Mask Maker", "Core Game", "God Mask" },
                    { 64, "Mask Maker", "Core Game", "Man Mask" },
                    { 65, "Mask Maker", "Core Game", "Phoenix Mask" },
                    { 66, "Mask Maker", "Core Game", "White Lion Mask" },
                    { 67, "Organ Grinder", "Core Game", "Dried Acanthus" },
                    { 68, "Organ Grinder", "Core Game", "Fecal Salve" },
                    { 69, "Organ Grinder", "Core Game", "Lucky Charm" },
                    { 70, "Organ Grinder", "Core Game", "Monster Grease" },
                    { 71, "Organ Grinder", "Core Game", "Monster Tooth Necklace" },
                    { 72, "Organ Grinder", "Core Game", "Stone Noses" },
                    { 73, "Plumery", "Core Game", "Arc Bow" },
                    { 74, "Plumery", "Core Game", "Bird Bread" },
                    { 75, "Plumery", "Core Game", "Blood Sheath" },
                    { 76, "Plumery", "Core Game", "Bloom Sphere" },
                    { 77, "Plumery", "Core Game", "Crest Crown" },
                    { 78, "Plumery", "Core Game", "Feather Mantle" },
                    { 79, "Plumery", "Core Game", "Feather Shield" },
                    { 80, "Plumery", "Core Game", "Finger of God" },
                    { 81, "Plumery", "Core Game", "Hollow Sword" },
                    { 82, "Plumery", "Core Game", "Hollowpoint Arrow" },
                    { 83, "Plumery", "Core Game", "Hours Ring" },
                    { 84, "Plumery", "Core Game", "Phoenix Faulds" },
                    { 85, "Plumery", "Core Game", "Phoenix Gauntlet" },
                    { 86, "Plumery", "Core Game", "Phoenix Greaves" },
                    { 87, "Plumery", "Core Game", "Phoenix Helm" },
                    { 88, "Plumery", "Core Game", "Phoenix Plackart" },
                    { 89, "Plumery", "Core Game", "Rainbow Katana" },
                    { 90, "Plumery", "Core Game", "Sonic Tomahawk" },
                    { 91, "Rare Gear", "Core Game", "Adventure Sword" },
                    { 92, "Rare Gear", "Core Game", "Butcher Cleaver" },
                    { 93, "Rare Gear", "Core Game", "Forsaker Mask" },
                    { 94, "Rare Gear", "Core Game", "Lantern Halberd" },
                    { 95, "Rare Gear", "Core Game", "Muramasa" },
                    { 96, "Rare Gear", "Core Game", "Regal Faulds" },
                    { 97, "Rare Gear", "Core Game", "Regal Gauntlet" },
                    { 98, "Rare Gear", "Core Game", "Regal Greaves" },
                    { 99, "Rare Gear", "Core Game", "Regal Helm" },
                    { 100, "Rare Gear", "Core Game", "Regal Plackart" },
                    { 101, "Rare Gear", "Core Game", "Steel Shield" },
                    { 102, "Rare Gear", "Core Game", "Steel Sword" },
                    { 103, "Rare Gear", "Core Game", "Thunder Maul" },
                    { 104, "Rare Gear", "Core Game", "Twilight Sword" },
                    { 105, "Skinnery", "Core Game", "Bandages" },
                    { 106, "Skinnery", "Core Game", "Rawhide Boots" },
                    { 107, "Skinnery", "Core Game", "Rawhide Drum" },
                    { 108, "Skinnery", "Core Game", "Rawhide Gloves" },
                    { 109, "Skinnery", "Core Game", "Rawhide Headband" },
                    { 110, "Skinnery", "Core Game", "Rawhide Pants" },
                    { 111, "Skinnery", "Core Game", "Rawhide Vest" },
                    { 112, "Skinnery", "Core Game", "Rawhide Whip" },
                    { 113, "Starting Gear", "Core Game", "Cloth" },
                    { 114, "Starting Gear", "Core Game", "Founding Stone" },
                    { 115, "Stone Circle", "Core Game", "Beast Knuckle" },
                    { 116, "Stone Circle", "Core Game", "Blood Paint" },
                    { 117, "Stone Circle", "Core Game", "Bone Earrings" },
                    { 118, "Stone Circle", "Core Game", "Boss Mehndi" },
                    { 119, "Stone Circle", "Core Game", "Brain Mint" },
                    { 120, "Stone Circle", "Core Game", "Elder Earrings" },
                    { 121, "Stone Circle", "Core Game", "Lance of Longinus" },
                    { 122, "Stone Circle", "Core Game", "Screaming Bracers" },
                    { 123, "Stone Circle", "Core Game", "Screaming Coat" },
                    { 124, "Stone Circle", "Core Game", "Screaming Horns" },
                    { 125, "Stone Circle", "Core Game", "Screaming Leg Warmers" },
                    { 126, "Stone Circle", "Core Game", "Screaming Skirt" },
                    { 127, "Stone Circle", "Core Game", "Speed Powder" },
                    { 128, "Weapon Crafter", "Core Game", "Counterweighted Axe" },
                    { 129, "Weapon Crafter", "Core Game", "Scrap Bone Spear" },
                    { 130, "Weapon Crafter", "Core Game", "Scrap Dagger" },
                    { 131, "Weapon Crafter", "Core Game", "Scrap Lantern" },
                    { 132, "Weapon Crafter", "Core Game", "Scrap Rebar" },
                    { 133, "Weapon Crafter", "Core Game", "Scrap Sword" },
                    { 134, "Weapon Crafter", "Core Game", "Skullcap Hammer" },
                    { 135, "Weapon Crafter", "Core Game", "Whistling Mace" },
                    { 136, "Weapon Crafter", "Core Game", "Zanbato" },
                    { 137, "Rare Gear", "Dragon King Expansion", "Celestial Spear" },
                    { 138, "Rare Gear", "Dragon King Expansion", "Husk of Destiny" },
                    { 139, "Rare Gear", "Dragon King Expansion", "Dragon Vestments" },
                    { 140, "Rare Gear", "Dragon King Expansion", "Hazmat Shield" },
                    { 141, "Rare Gear", "Dragon King Expansion", "Regal Edge" },
                    { 142, "Dragon Armory", "Dragon King Expansion", "Blast Shield" },
                    { 143, "Dragon Armory", "Dragon King Expansion", "Blast Sword" },
                    { 144, "Dragon Armory", "Dragon King Expansion", "Blue Power Core" },
                    { 145, "Dragon Armory", "Dragon King Expansion", "Dragon Belt" },
                    { 146, "Dragon Armory", "Dragon King Expansion", "Dragon Bite Bolt" },
                    { 147, "Dragon Armory", "Dragon King Expansion", "Dragon Boots" },
                    { 148, "Dragon Armory", "Dragon King Expansion", "Dragon Chakram" },
                    { 149, "Dragon Armory", "Dragon King Expansion", "Dragon Gloves" },
                    { 150, "Dragon Armory", "Dragon King Expansion", "Dragon Mantle" },
                    { 151, "Dragon Armory", "Dragon King Expansion", "Dragonskull Helm" },
                    { 152, "Dragon Armory", "Dragon King Expansion", "Nuclear Knife" },
                    { 153, "Dragon Armory", "Dragon King Expansion", "Nuclear Scythe" },
                    { 154, "Dragon Armory", "Dragon King Expansion", "Red Power Core" },
                    { 155, "Dragon Armory", "Dragon King Expansion", "Shielded Quiver" },
                    { 156, "Dragon Armory", "Dragon King Expansion", "Talon Knife" },
                    { 157, "Rare Gear", "Dung Beetle Knight Expansion", "Calcified Digging Claw" },
                    { 158, "Rare Gear", "Dung Beetle Knight Expansion", "Calcified Greaves" },
                    { 159, "Rare Gear", "Dung Beetle Knight Expansion", "Calcified Juggernaut Blade" },
                    { 160, "Rare Gear", "Dung Beetle Knight Expansion", "Calcified Shoulder Pads" },
                    { 161, "Rare Gear", "Dung Beetle Knight Expansion", "Calcified Zanbato" },
                    { 162, "Rare Gear", "Dung Beetle Knight Expansion", "Hidden Crimson Jewel" },
                    { 163, "Rare Gear", "Dung Beetle Knight Expansion", "Regenerating Blade" },
                    { 164, "Rare Gear", "Dung Beetle Knight Expansion", "Trash Crown" },
                    { 165, "Wet Resin Crafter", "Dung Beetle Knight Expansion", "Century Greaves" },
                    { 166, "Wet Resin Crafter", "Dung Beetle Knight Expansion", "Century Shoulder Pads" },
                    { 167, "Wet Resin Crafter", "Dung Beetle Knight Expansion", "DBK Errant Badge" },
                    { 168, "Wet Resin Crafter", "Dung Beetle Knight Expansion", "Digging Claws" },
                    { 169, "Wet Resin Crafter", "Dung Beetle Knight Expansion", "Rainbow Wing Belt" },
                    { 170, "Wet Resin Crafter", "Dung Beetle Knight Expansion", "Rubber Bone Harness" },
                    { 171, "Wet Resin Crafter", "Dung Beetle Knight Expansion", "Scarab Circlet" },
                    { 172, "Wet Resin Crafter", "Dung Beetle Knight Expansion", "Seasoned Monster Meat" },
                    { 173, "Wet Resin Crafter", "Dung Beetle Knight Expansion", "The Beetle Bomb" },
                    { 174, "Rare Gear", "Flower Knight Expansion", "Flower Knight Badge" },
                    { 175, "Rare Gear", "Flower Knight Expansion", "Flower Knight Helm" },
                    { 176, "Rare Gear", "Flower Knight Expansion", "Replica Flower Sword" },
                    { 177, "Rare Gear", "Flower Knight Expansion", "Sleeping Flower Virus" },
                    { 178, "Sense-Memory", "Flower Knight Expansion", "Vespertine Arrow" },
                    { 179, "Sense-Memory", "Flower Knight Expansion", "Vespertine Bow" },
                    { 180, "Sense-Memory", "Flower Knight Expansion", "Vespertine Cello" },
                    { 181, "Sense-Memory", "Flower Knight Expansion", "Vespertine Foil" },
                    { 182, "Sense-Memory", "Flower Knight Expansion", "Satchel" },
                    { 183, "Gormchymist", "Gorm Expansion", "Healing Potion" },
                    { 184, "Gormchymist", "Gorm Expansion", "Life Elixir" },
                    { 185, "Gormchymist", "Gorm Expansion", "Power Potion" },
                    { 186, "Gormchymist", "Gorm Expansion", "Steadfast Potion" },
                    { 187, "Gormchymist", "Gorm Expansion", "Wisdom Potion" },
                    { 188, "Gormery", "Gorm Expansion", "Acid-Tooth Dagger" },
                    { 189, "Gormery", "Gorm Expansion", "Armor Spikes" },
                    { 190, "Gormery", "Gorm Expansion", "Black Sword" },
                    { 191, "Gormery", "Gorm Expansion", "Gaxe" },
                    { 192, "Gormery", "Gorm Expansion", "Gorment Boots" },
                    { 193, "Gormery", "Gorm Expansion", "Gorment Mask" },
                    { 194, "Gormery", "Gorm Expansion", "Gorment Sleeves" },
                    { 195, "Gormery", "Gorm Expansion", "Gorment Suit" },
                    { 196, "Gormery", "Gorm Expansion", "Gorn" },
                    { 197, "Gormery", "Gorm Expansion", "Greater Gaxe" },
                    { 198, "Gormery", "Gorm Expansion", "Knuckle Shield" },
                    { 199, "Gormery", "Gorm Expansion", "Pulse Lantern" },
                    { 200, "Gormery", "Gorm Expansion", "Regeneration Suit" },
                    { 201, "Gormery", "Gorm Expansion", "Rib Blade" },
                    { 202, "Gormery", "Gorm Expansion", "Riot Mace" },
                    { 203, "Rare Gear", "Lion God Expansion", "Ancient Lion Claws" },
                    { 204, "Rare Gear", "Lion God Expansion", "Bone Witch Mehndi" },
                    { 205, "Rare Gear", "Lion God Expansion", "Butcher's Blood" },
                    { 206, "Rare Gear", "Lion God Expansion", "Death Mehndi" },
                    { 207, "Rare Gear", "Lion God Expansion", "Glyph of Solitude" },
                    { 208, "Rare Gear", "Lion God Expansion", "Golden Plate" },
                    { 209, "Rare Gear", "Lion God Expansion", "Lantern Mehndi" },
                    { 210, "Rare Gear", "Lion God Expansion", "Lion God Statue" },
                    { 211, "Rare Gear", "Lion God Expansion", "Necromancer's Eye" },
                    { 212, "Rare Gear", "Lion Knight Expansion", "Hideous Disguise" },
                    { 213, "Rare Gear", "Lion Knight Expansion", "Lion Knight Badge" },
                    { 214, "Rare Gear", "Lion Knight Expansion", "Lion Knight's Left Claw" },
                    { 215, "Rare Gear", "Lion Knight Expansion", "Lion Knight's Right Claw" },
                    { 216, "Rare Gear", "Manhunter Expansion", "Deathpact" },
                    { 217, "Rare Gear", "Manhunter Expansion", "Hunter's Heart" },
                    { 218, "Rare Gear", "Manhunter Expansion", "Manhunter's Hat" },
                    { 219, "Rare Gear", "Manhunter Expansion", "Reverberating Lantern" },
                    { 220, "Rare Gear", "Manhunter Expansion", "Tool Belt" },
                    { 221, "Light-Forging", "Slenderman Expansion", "Dark Water Vial" },
                    { 222, "Light-Forging", "Slenderman Expansion", "Gloom Bracelets" },
                    { 223, "Light-Forging", "Slenderman Expansion", "Gloom Cream" },
                    { 224, "Light-Forging", "Slenderman Expansion", "Gloom Hammer" },
                    { 225, "Light-Forging", "Slenderman Expansion", "Gloom Katana" },
                    { 226, "Light-Forging", "Slenderman Expansion", "Gloom Mehndi" },
                    { 227, "Light-Forging", "Slenderman Expansion", "Gloom Sheath" },
                    { 228, "Light-Forging", "Slenderman Expansion", "Gloom-Coated Arrow" },
                    { 229, "Light-Forging", "Slenderman Expansion", "Raptor-Worm Collar" },
                    { 230, "Light-Forging", "Slenderman Expansion", "Slender Ovule" },
                    { 231, "Rare Gear", "Sunstalker Expansion", "Eyepatch" },
                    { 232, "Rare Gear", "Sunstalker Expansion", "God's String" },
                    { 233, "Sacred Pool", "Sunstalker Expansion", "Apostle Crown" },
                    { 234, "Sacred Pool", "Sunstalker Expansion", "Prism Mace" },
                    { 235, "Sacred Pool", "Sunstalker Expansion", "Sun Vestments" },
                    { 236, "Sacred Pool", "Sunstalker Expansion", "Sunring Bow" },
                    { 237, "Skyreef Sanctuary", "Sunstalker Expansion", "Cycloid Scale Hood" },
                    { 238, "Skyreef Sanctuary", "Sunstalker Expansion", "Cycloid Scale Jacket" },
                    { 239, "Skyreef Sanctuary", "Sunstalker Expansion", "Cycloid Scale Shoes" },
                    { 240, "Skyreef Sanctuary", "Sunstalker Expansion", "Cycloid Scale Skirt" },
                    { 241, "Skyreef Sanctuary", "Sunstalker Expansion", "Cycloid Scale Sleeves" },
                    { 242, "Skyreef Sanctuary", "Sunstalker Expansion", "Denticle Axe" },
                    { 243, "Skyreef Sanctuary", "Sunstalker Expansion", "Ink Blood Bow" },
                    { 244, "Skyreef Sanctuary", "Sunstalker Expansion", "Ink Sword" },
                    { 245, "Skyreef Sanctuary", "Sunstalker Expansion", "Quiver & Sun String" },
                    { 246, "Skyreef Sanctuary", "Sunstalker Expansion", "Shadow Saliva Shawl" },
                    { 247, "Skyreef Sanctuary", "Sunstalker Expansion", "Skleaver" },
                    { 248, "Skyreef Sanctuary", "Sunstalker Expansion", "Sky Harpoon" },
                    { 249, "Skyreef Sanctuary", "Sunstalker Expansion", "Sun Lure and Hook" },
                    { 250, "Skyreef Sanctuary", "Sunstalker Expansion", "Sunshark Arrows" },
                    { 251, "Skyreef Sanctuary", "Sunstalker Expansion", "Sunshark Bow" },
                    { 252, "Skyreef Sanctuary", "Sunstalker Expansion", "Sunspot Dart" },
                    { 253, "Skyreef Sanctuary", "Sunstalker Expansion", "Sunspot Lantern" },
                    { 254, "Rare Gear", "Spidicules Expansion", "Grinning Visage" },
                    { 255, "Rare Gear", "Spidicules Expansion", "The Weaver" },
                    { 256, "Silk Mill", "Spidicules Expansion", "Amber Edge" },
                    { 257, "Silk Mill", "Spidicules Expansion", "Amber Poleaxe" },
                    { 258, "Silk Mill", "Spidicules Expansion", "Blue Ring" },
                    { 259, "Silk Mill", "Spidicules Expansion", "Body Suit" },
                    { 260, "Silk Mill", "Spidicules Expansion", "Green Ring" },
                    { 261, "Silk Mill", "Spidicules Expansion", "Hooded Scrap Katar" },
                    { 262, "Silk Mill", "Spidicules Expansion", "Red Ring" },
                    { 263, "Silk Mill", "Spidicules Expansion", "Silk Bomb" },
                    { 264, "Silk Mill", "Spidicules Expansion", "Silk Boots" },
                    { 265, "Silk Mill", "Spidicules Expansion", "Silk Robes" },
                    { 266, "Silk Mill", "Spidicules Expansion", "Silk Sash" },
                    { 267, "Silk Mill", "Spidicules Expansion", "Silk Turban" },
                    { 268, "Silk Mill", "Spidicules Expansion", "Silk Whip" },
                    { 269, "Silk Mill", "Spidicules Expansion", "Silk Wraps" },
                    { 270, "Silk Mill", "Spidicules Expansion", "Throwing Knife" },
                    { 271, "Green Knight", "Green Knight Expansion", "Fetorsaurus" },
                    { 272, "Green Knight", "Green Knight Expansion", "Green Boots" },
                    { 273, "Green Knight", "Green Knight Expansion", "Green Faulds" },
                    { 274, "Green Knight", "Green Knight Expansion", "Green Gloves" },
                    { 275, "Green Knight", "Green Knight Expansion", "Green Helm" },
                    { 276, "Green Knight", "Green Knight Expansion", "Green Plate" },
                    { 277, "Green Knight", "Green Knight Expansion", "Griswaldo" }
                });

            migrationBuilder.InsertData(
                schema: "KD",
                table: "Resources",
                columns: new[] { "Id", "Category", "Expansion", "Name" },
                values: new object[,]
                {
                    { 1, "Basic Resource", "Core Game", "???" },
                    { 2, "Basic Resource", "Core Game", "Broken Lantern" },
                    { 3, "Basic Resource", "Core Game", "Love Juice" },
                    { 4, "Basic Resource", "Core Game", "Lump of Atnas" },
                    { 5, "Basic Resource", "Core Game", "Monster Bone" },
                    { 6, "Basic Resource", "Core Game", "Monster Hide" },
                    { 7, "Basic Resource", "Core Game", "Monster Organ" },
                    { 8, "Basic Resource", "Core Game", "Perfect Bone" },
                    { 9, "Basic Resource", "Core Game", "Perfect Hide" },
                    { 10, "Basic Resource", "Core Game", "Perfect Organ" },
                    { 11, "Basic Resource", "Core Game", "Skull" },
                    { 12, "Phoenix Resource", "Core Game", "Bird Beak" },
                    { 13, "Phoenix Resource", "Core Game", "Black Skull" },
                    { 14, "Phoenix Resource", "Core Game", "Hollow Wing Bones" },
                    { 15, "Phoenix Resource", "Core Game", "Muculent Droppings" },
                    { 16, "Phoenix Resource", "Core Game", "Phoenix Eye" },
                    { 17, "Phoenix Resource", "Core Game", "Phoenix Finger" },
                    { 18, "Phoenix Resource", "Core Game", "Phoenix Whisker" },
                    { 19, "Phoenix Resource", "Core Game", "Pustules" },
                    { 20, "Phoenix Resource", "Core Game", "Rainbow Droppings" },
                    { 21, "Phoenix Resource", "Core Game", "Shimmering Halo" },
                    { 22, "Phoenix Resource", "Core Game", "Small Feathers" },
                    { 23, "Phoenix Resource", "Core Game", "Small Hand Parasites" },
                    { 24, "Phoenix Resource", "Core Game", "Tail Feathers" },
                    { 25, "Phoenix Resource", "Core Game", "Wishbone" },
                    { 26, "Screaming Antelope Resource", "Core Game", "Beast Steak" },
                    { 27, "Screaming Antelope Resource", "Core Game", "Bladder" },
                    { 28, "Screaming Antelope Resource", "Core Game", "Large Flat Tooth" },
                    { 29, "Screaming Antelope Resource", "Core Game", "Muscly Gums" },
                    { 30, "Screaming Antelope Resource", "Core Game", "Pelt" },
                    { 31, "Screaming Antelope Resource", "Core Game", "Screaming Brain" },
                    { 32, "Screaming Antelope Resource", "Core Game", "Shank Bone" },
                    { 33, "Screaming Antelope Resource", "Core Game", "Spiral Horn" },
                    { 34, "White Lion Resource", "Core Game", "Curious Hand" },
                    { 35, "White Lion Resource", "Core Game", "Eye of Cat" },
                    { 36, "White Lion Resource", "Core Game", "Golden Whiskers" },
                    { 37, "White Lion Resource", "Core Game", "Great Cat Bones" },
                    { 38, "White Lion Resource", "Core Game", "Lion Claw" },
                    { 39, "White Lion Resource", "Core Game", "Lion Tail" },
                    { 40, "White Lion Resource", "Core Game", "Lion Testes" },
                    { 41, "White Lion Resource", "Core Game", "Shimmering Mane" },
                    { 42, "White Lion Resource", "Core Game", "Sinew" },
                    { 43, "White Lion Resource", "Core Game", "White Fur" },
                    { 44, "Strange Resource", "Core Game", "Black Lichen" },
                    { 45, "Strange Resource", "Core Game", "Cocoon Membrane" },
                    { 46, "Strange Resource", "Core Game", "Elder Cat Teeth" },
                    { 47, "Strange Resource", "Core Game", "Fresh Acanthus" },
                    { 48, "Strange Resource", "Core Game", "Iron" },
                    { 49, "Strange Resource", "Core Game", "Lantern Tube" },
                    { 50, "Strange Resource", "Core Game", "Leather" },
                    { 51, "Strange Resource", "Core Game", "Perfect Crucible" },
                    { 52, "Strange Resource", "Core Game", "Phoenix Crest" },
                    { 53, "Strange Resource", "Core Game", "Legendary Horns" },
                    { 54, "Strange Resource", "Core Game", "Second Heart" },
                    { 55, "Dragon King Resource", "Dragon King Expansion", "Cabled Vein" },
                    { 56, "Dragon King Resource", "Dragon King Expansion", "Dragon Iron" },
                    { 57, "Dragon King Resource", "Dragon King Expansion", "Hardened Ribs" },
                    { 58, "Dragon King Resource", "Dragon King Expansion", "Horn Fragment" },
                    { 59, "Dragon King Resource", "Dragon King Expansion", "Husk" },
                    { 60, "Dragon King Resource", "Dragon King Expansion", "King’s Claws" },
                    { 61, "Dragon King Resource", "Dragon King Expansion", "King's Tongue" },
                    { 62, "Dragon King Resource", "Dragon King Expansion", "Radioactive Dung" },
                    { 63, "Dragon King Resource", "Dragon King Expansion", "Veined Wing" },
                    { 64, "Strange Resource", "Dragon King Expansion", "Pituitary Gland" },
                    { 65, "Strange Resource", "Dragon King Expansion", "Radiant Heart" },
                    { 66, "Strange Resource", "Dragon King Expansion", "Shining Liver" },
                    { 67, "Dung Beetle Knight Resource", "Dung Beetle Knight Expansion", "Beetle Horn" },
                    { 68, "Dung Beetle Knight Resource", "Dung Beetle Knight Expansion", "Century Fingernails" },
                    { 69, "Dung Beetle Knight Resource", "Dung Beetle Knight Expansion", "Century Shell" },
                    { 70, "Dung Beetle Knight Resource", "Dung Beetle Knight Expansion", "Compound Eye" },
                    { 71, "Dung Beetle Knight Resource", "Dung Beetle Knight Expansion", "Elytra" },
                    { 72, "Dung Beetle Knight Resource", "Dung Beetle Knight Expansion", "Scarab Shell" },
                    { 73, "Dung Beetle Knight Resource", "Dung Beetle Knight Expansion", "Scarab Wing" },
                    { 74, "Dung Beetle Knight Resource", "Dung Beetle Knight Expansion", "Underplate Fungus" },
                    { 75, "Strange Resource", "Dung Beetle Knight Expansion", "Preserved Caustic Dung" },
                    { 76, "Strange Resource", "Dung Beetle Knight Expansion", "Scell" },
                    { 77, "Flower Knight Resource", "Flower Knight Expansion", "Warbling Bloom" },
                    { 78, "Flower Knight Resource", "Flower Knight Expansion", "Osseous Bloom" },
                    { 79, "Flower Knight Resource", "Flower Knight Expansion", "Sighing Bloom" },
                    { 80, "Flower Knight Resource", "Flower Knight Expansion", "Lantern Bloom" },
                    { 81, "Flower Knight Resource", "Flower Knight Expansion", "Lantern Bud" },
                    { 82, "Gorm Resource", "Gorm Expansion", "Dense Bone" },
                    { 83, "Gorm Resource", "Gorm Expansion", "Stout Vertebrae" },
                    { 84, "Gorm Resource", "Gorm Expansion", "Stout Hide" },
                    { 85, "Gorm Resource", "Gorm Expansion", "Mammoth Hand" },
                    { 86, "Gorm Resource", "Gorm Expansion", "Jiggling Lard" },
                    { 87, "Gorm Resource", "Gorm Expansion", "Milky Eye" },
                    { 88, "Gorm Resource", "Gorm Expansion", "Meaty Rib" },
                    { 89, "Gorm Resource", "Gorm Expansion", "Handed Skull" },
                    { 90, "Gorm Resource", "Gorm Expansion", "Gorm Brain" },
                    { 91, "Gorm Resource", "Gorm Expansion", "Stout Kidney" },
                    { 92, "Gorm Resource", "Gorm Expansion", "Stout Heart" },
                    { 93, "Gorm Resource", "Gorm Expansion", "Acid Gland" },
                    { 94, "Strange Resource", "Gorm Expansion", "Pure Bulb" },
                    { 95, "Strange Resource", "Gorm Expansion", "Active Thyroid" },
                    { 96, "Strange Resource", "Gorm Expansion", "Stomach Lining" },
                    { 97, "Strange Resource", "Gorm Expansion", "Gormite" },
                    { 98, "Strange Resource", "Lion God Expansion", "Canopic Jar" },
                    { 99, "Strange Resource", "Lion God Expansion", "Old Blue Box" },
                    { 100, "Strange Resource", "Lion God Expansion", "Sarcophagus" },
                    { 101, "Strange Resource", "Lion God Expansion", "Silver Urn" },
                    { 102, "Strange Resource", "Lion God Expansion", "Triptych" },
                    { 103, "Strange Resource", "Lonely Tree Expansion", "Blistering Plasma Fruit" },
                    { 104, "Strange Resource", "Lonely Tree Expansion", "Drifting Dream Fruit" },
                    { 105, "Strange Resource", "Lonely Tree Expansion", "Jagged Marrow Fruit" },
                    { 106, "Strange Resource", "Lonely Tree Expansion", "Lonely Fruit" },
                    { 107, "Strange Resource", "Lonely Tree Expansion", "Porous Flesh Fruit" },
                    { 108, "Strange Resource", "Manhunter Expansion", "Crimson Vial" },
                    { 109, "Strange Resource", "Manhunter Expansion", "Red Vial" },
                    { 110, "Strange Resource", "Slenderman Expansion", "Crystal Sword Mold" },
                    { 111, "Strange Resource", "Slenderman Expansion", "Dark Water" },
                    { 112, "Sunstalker Resource", "Sunstalker Expansion", "Black Lens" },
                    { 113, "Sunstalker Resource", "Sunstalker Expansion", "Brain Root" },
                    { 114, "Sunstalker Resource", "Sunstalker Expansion", "Cycloid Scales" },
                    { 115, "Sunstalker Resource", "Sunstalker Expansion", "Fertility Tentacle" },
                    { 116, "Sunstalker Resource", "Sunstalker Expansion", "Huge Sunteeth" },
                    { 117, "Sunstalker Resource", "Sunstalker Expansion", "Inner Shadow Skin" },
                    { 118, "Sunstalker Resource", "Sunstalker Expansion", "Prismatic Gills" },
                    { 119, "Sunstalker Resource", "Sunstalker Expansion", "Shadow Ink Gland" },
                    { 120, "Sunstalker Resource", "Sunstalker Expansion", "Shadow Tentacles" },
                    { 121, "Sunstalker Resource", "Sunstalker Expansion", "Shark Tongue" },
                    { 122, "Sunstalker Resource", "Sunstalker Expansion", "Small Sunteeth" },
                    { 123, "Sunstalker Resource", "Sunstalker Expansion", "Stink Lung" },
                    { 124, "Sunstalker Resource", "Sunstalker Expansion", "Sunshark Blubber" },
                    { 125, "Sunstalker Resource", "Sunstalker Expansion", "Sunshark Bone" },
                    { 126, "Sunstalker Resource", "Sunstalker Expansion", "Sunshark Fin" },
                    { 127, "Sunstalker Resource", "Sunstalker Expansion", "Sunstones" },
                    { 128, "Strange Resource", "Sunstalker Expansion", "1,000 Year Sunspot" },
                    { 129, "Strange Resource", "Sunstalker Expansion", "3,000 Year Sunspot" },
                    { 130, "Strange Resource", "Sunstalker Expansion", "Bugfish" },
                    { 131, "Strange Resource", "Sunstalker Expansion", "Hagfish" },
                    { 132, "Strange Resource", "Sunstalker Expansion", "Jowls" },
                    { 133, "Strange Resource", "Sunstalker Expansion", "Salt" },
                    { 134, "Strange Resource", "Sunstalker Expansion", "Sunstones" },
                    { 135, "Spidicules Resource", "Spidicules Expansion", "Arachnid Heart" },
                    { 136, "Spidicules Resource", "Spidicules Expansion", "Chitin" },
                    { 137, "Spidicules Resource", "Spidicules Expansion", "Exoskeleton" },
                    { 138, "Spidicules Resource", "Spidicules Expansion", "Eyeballs" },
                    { 139, "Spidicules Resource", "Spidicules Expansion", "Large Appendage" },
                    { 140, "Spidicules Resource", "Spidicules Expansion", "Serrated Fangs" },
                    { 141, "Spidicules Resource", "Spidicules Expansion", "Small Appendages" },
                    { 142, "Spidicules Resource", "Spidicules Expansion", "Spinnerets" },
                    { 143, "Spidicules Resource", "Spidicules Expansion", "Stomach" },
                    { 144, "Spidicules Resource", "Spidicules Expansion", "Thick Web Silk" },
                    { 145, "Spidicules Resource", "Spidicules Expansion", "Unlaid Eggs" },
                    { 146, "Spidicules Resource", "Spidicules Expansion", "Venom Sac" },
                    { 147, "Strange Resource", "Spidicules Expansion", "Web Silk" },
                    { 148, "Strange Resource", "Spidicules Expansion", "Silken Nervous System" }
                });

            migrationBuilder.InsertData(
                schema: "KD",
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Amber" },
                    { 2, "Ammunation" },
                    { 3, "Armor" },
                    { 4, "Arrow" },
                    { 5, "Axe" },
                    { 6, "Badge" },
                    { 7, "Balm" },
                    { 8, "Bone (Gear)" },
                    { 9, "Bone (Resource)" },
                    { 10, "Bow" },
                    { 11, "Cloth" },
                    { 12, "Club" },
                    { 13, "Consumable" },
                    { 14, "Dagger" },
                    { 15, "Feather" },
                    { 16, "Finesse" },
                    { 17, "Fish" },
                    { 18, "Flammable" },
                    { 19, "Flower" },
                    { 20, "Fragile" },
                    { 21, "Fur" },
                    { 22, "Gloomy" },
                    { 23, "Gormskin" },
                    { 24, "Grand" },
                    { 25, "Gun" },
                    { 26, "Heavy" },
                    { 27, "Herb" },
                    { 28, "Hide" },
                    { 29, "Instrument" },
                    { 30, "Iron" },
                    { 31, "Item" },
                    { 32, "Ivory" },
                    { 33, "Jewelry" },
                    { 34, "Katana" },
                    { 35, "Katar" },
                    { 36, "Knight" },
                    { 37, "Lantern" },
                    { 38, "Leather" },
                    { 39, "Mask" },
                    { 40, "Melee" },
                    { 41, "Metal" },
                    { 42, "Mineral" },
                    { 43, "Noisy" },
                    { 44, "Nuclear" },
                    { 45, "Order" },
                    { 46, "Organ" },
                    { 47, "Other" },
                    { 48, "Perfect" },
                    { 49, "Pickaxe" },
                    { 50, "Ranged" },
                    { 51, "Rawhide" },
                    { 52, "Scale" },
                    { 53, "Scimitar" },
                    { 54, "Scrap" },
                    { 55, "Scythe" },
                    { 56, "Set" },
                    { 57, "Shield" },
                    { 58, "Sickle" },
                    { 59, "Silk" },
                    { 60, "Soluble" },
                    { 61, "Spear" },
                    { 62, "Steel" },
                    { 63, "Stinky" },
                    { 64, "Stone" },
                    { 65, "Sword" },
                    { 66, "Symbol" },
                    { 67, "Tool" },
                    { 68, "Two-handed" },
                    { 69, "Vegetable" },
                    { 70, "Weapon" },
                    { 71, "Whip" },
                    { 72, "Resource" }
                });

            migrationBuilder.InsertData(
                schema: "KD",
                table: "Costs",
                columns: new[] { "Id", "Amount", "GearId", "ResourceId", "TagId" },
                values: new object[,]
                {
                    { 1, 2, 1, 50, null },
                    { 2, 1, 2, 10, null },
                    { 3, 1, 3, 10, null },
                    { 4, 2, 3, null, 9 },
                    { 5, 1, 4, 50, null },
                    { 6, 1, 4, 8, null },
                    { 7, 1, 5, 9, null },
                    { 8, 7, 6, null, 72 },
                    { 9, 1, 7, 8, null },
                    { 10, 1, 8, null, 54 },
                    { 11, 1, 8, 9, null },
                    { 12, 2, 9, 48, null },
                    { 13, 3, 9, 50, null },
                    { 14, 4, 9, null, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Costs_GearId",
                schema: "KD",
                table: "Costs",
                column: "GearId");

            migrationBuilder.CreateIndex(
                name: "IX_Costs_ResourceId",
                schema: "KD",
                table: "Costs",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Costs_TagId",
                schema: "KD",
                table: "Costs",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_GearTag_TagsId",
                schema: "KD",
                table: "GearTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceTag_TagsId",
                schema: "KD",
                table: "ResourceTag",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Costs",
                schema: "KD");

            migrationBuilder.DropTable(
                name: "GearTag",
                schema: "KD");

            migrationBuilder.DropTable(
                name: "ResourceTag",
                schema: "KD");

            migrationBuilder.DropTable(
                name: "Gears",
                schema: "KD");

            migrationBuilder.DropTable(
                name: "Resources",
                schema: "KD");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "KD");
        }
    }
}

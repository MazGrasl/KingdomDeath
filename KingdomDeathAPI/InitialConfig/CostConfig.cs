public static class CostConfig {

    static int index = 0;
    static Cost AlmanacLeather = new() {
        Id = ++index,
        GearId = 1,
        Amount = 2,
        ResourceId = 50
    };
    static Cost BlueCharmPOrgan = new() {
        Id = ++index,
        GearId = 2,
        Amount = 1,
        ResourceId = 10
    };
    static Cost BugTrapPOrgan = new() {
        Id = ++index,
        GearId = 3,
        Amount = 1,
        ResourceId = 10
    };
    static Cost BugTrapBone = new() {
        Id = ++index,
        GearId = 3,
        Amount = 2,
        TagId = 9
    };
    static Cost FirstAidKitLeather = new() {
        Id = ++index,
        GearId = 4,
        Amount = 1,
        ResourceId = 50
    };
    static Cost FirstAidKitPBone = new() {
        Id = ++index,
        GearId = 4,
        Amount = 1,
        ResourceId = 8
    };
    static Cost GreenCharmPHide = new() {
        Id = ++index,
        GearId = 5,
        Amount = 1,
        ResourceId = 9
    };
    static Cost MuskBombResources = new() {
        Id = ++index,
        GearId = 6,
        Amount = 7,
        TagId = 72
    };
    static Cost RedCharmPBone = new() {
        Id = ++index,
        GearId = 7,
        Amount = 1,
        ResourceId = 8
    };
    static Cost ScavengerKitScrap = new() {
        Id = ++index,
        GearId = 8,
        Amount = 1,
        TagId = 54
    };
    static Cost ScavengerKitPHide = new() {
        Id = ++index,
        GearId = 8,
        Amount = 1,
        ResourceId = 9
    };
    static Cost BeaconShieldIron = new() {
        Id = ++index,
        GearId = 9,
        Amount = 2,
        ResourceId = 48
    };
    static Cost BeaconShieldLeather = new() {
        Id = ++index,
        GearId = 9,
        Amount = 3,
        ResourceId = 50
    };
    static Cost BeaconShieldBone = new() {
        Id = ++index,
        GearId = 9,
        Amount = 4,
        TagId = 9
    };


    // https://kingdomdeath.fandom.com/wiki/Gear
    public static List<Cost> costs = [
        AlmanacLeather,
        BlueCharmPOrgan,
        BugTrapPOrgan,
        BugTrapBone,
        FirstAidKitLeather,
        FirstAidKitPBone,
        GreenCharmPHide,
        MuskBombResources,
        RedCharmPBone,
        ScavengerKitScrap,
        ScavengerKitPHide,
        BeaconShieldIron,
        BeaconShieldLeather,
        BeaconShieldBone
    ];
}
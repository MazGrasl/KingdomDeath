using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

    }

    public DbSet<Gear> Gears { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Cost> Costs { get; set; }
    public DbSet<GearTag> GearTags { get; set; }
    public DbSet<ResourceTag> ResourceTags { get; set; }
    public DbSet<Settlement> Settlements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.HasDefaultSchema("KD");
        modelBuilder.Entity<Gear>().HasMany(item => item.Tags).WithMany(tag => tag.Gears).UsingEntity<GearTag>();
        modelBuilder.Entity<Resource>().HasMany(item => item.Tags).WithMany(tag => tag.Resources).UsingEntity<ResourceTag>();
        modelBuilder.Entity<Gear>().HasMany(item => item.Costs).WithOne(cost => cost.Gear).IsRequired();
        modelBuilder.Entity<Cost>().HasOne(cost => cost.Resource).WithMany(resource => resource.Costs);
        modelBuilder.Entity<SettlementGearStorageItem>().HasKey(item => new { item.SettlementId, item.GearId });
        modelBuilder.Entity<SettlementResourceStorageItem>().HasKey(item => new { item.SettlementId, item.ResourceId });
        List<Tag> tags = TagConfig.createTagList();
        modelBuilder.Entity<Tag>().HasData(tags);
        List<Gear> gear = GearConfig.createGearList();
        List<Resource> resources = ResourceConfig.createResourceList();
        List<Cost> costs = CostConfig.costs;
        modelBuilder.Entity<Gear>().HasData(gear);
        modelBuilder.Entity<Resource>().HasData(resources);
        modelBuilder.Entity<Cost>().HasData(costs);
    }
}
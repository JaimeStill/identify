using Identify.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace Identify.Data;
public class AppDbContext : DbContext
{
    public DbSet<Adventurer> Adventurers { get; set; }
    public DbSet<AdventurerAccessory> AdventurerAccessories { get; set; }
    public DbSet<AdventurerEye> AdventurerEyes { get; set; }
    public DbSet<AdventurerEyebrow> AdventurerEyebrows { get; set; }
    public DbSet<AdventurerHair> AdventurerHairs { get; set; }
    public DbSet<AdventurerMouth> AdventurerMouths { get; set; }
    public DbSet<Bot> Bots { get; set; }
    public DbSet<BotColor> BotColors { get; set; }
    public DbSet<Make> Makes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        SavingChanges += CompleteEntity;
    }

    private IEnumerable<EntityEntry> ChangeTrackerEntities() =>
        ChangeTracker
            .Entries()
            .Where(x => x.Entity is Entity);

    private bool EntitiesChanged() =>
        ChangeTrackerEntities().Any();

    private void CompleteEntity(object sender, SavingChangesEventArgs e)
    {
        if (EntitiesChanged())
        {
            var entities = ChangeTrackerEntities()
                .Select(x => x.Entity)
                .Cast<Entity>();

            foreach (Entity entity in entities)
                entity.Complete();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly()
        );

        modelBuilder
            .Model
            .GetEntityTypes()
            .Where(x => x.BaseType == null)
            .ToList()
            .ForEach(x =>
                modelBuilder
                    .Entity(x.Name)
                    .ToTable(x.DisplayName())
            );
    }
}

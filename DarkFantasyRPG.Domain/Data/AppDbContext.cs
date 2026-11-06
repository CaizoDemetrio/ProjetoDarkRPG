using DarkFantasyRPG.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DarkFantasyRPG.Domain.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Player> Players => Set<Player>();
    public DbSet<Item> Items => Set<Item>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Mapeamento do relacionamento entre Player e seus Items
        modelBuilder.Entity<Player>()
            .HasMany(p => p.Inventory)
            .WithOne();
    }
}
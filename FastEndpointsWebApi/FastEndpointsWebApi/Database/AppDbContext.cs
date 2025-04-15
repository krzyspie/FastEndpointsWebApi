using FastEndpointsWebApi.Cars.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastEndpointsWebApi.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>().HasKey(c => c.Id);
        modelBuilder.Entity<Car>().Property(c => c.Make).IsRequired().HasMaxLength(50);
        modelBuilder.Entity<Car>().Property(c => c.Model).IsRequired().HasMaxLength(50);
        modelBuilder.Entity<Car>().Property(c => c.Year).IsRequired();
        modelBuilder.Entity<Car>().Property(c => c.Color).HasMaxLength(20);
        modelBuilder.Entity<Car>().Property(c => c.EngineType).HasMaxLength(20);
        modelBuilder.Entity<Car>().Property(c => c.Transmission).HasMaxLength(20);
        modelBuilder.Entity<Car>().Property(c => c.Horsepower).IsRequired();
    }
}

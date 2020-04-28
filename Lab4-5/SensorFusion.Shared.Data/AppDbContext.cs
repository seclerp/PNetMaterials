using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SensorFusion.Shared.Data.Entities;

namespace SensorFusion.Shared.Data
{
  public class AppDbContext : IdentityDbContext<User>
  {
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<SensorValue> SensorValues { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<SensorValue>()
        .HasKey(o => new { o.SensorId, o.TimeSent });
    }
  }
}
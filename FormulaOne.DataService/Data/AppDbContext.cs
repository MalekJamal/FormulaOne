using Microsoft.EntityFrameworkCore;
using FormulaOne.Entities.DbSet;

namespace FormulaOne.DataService.Data;

public class AppDbContext : DbContext
{

    // Define the entities
    public virtual DbSet<Driver> Drivers { get; set; }
    public virtual DbSet<Achievements> Achievements { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Dtermiane the relationship between the entities 
        modelBuilder.Entity<Achievements>(entity =>
        {
            entity.HasOne(d => d.Driver).WithMany(p => p.Achievements).HasForeignKey(d => d.DriverId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("Fk_Achievements_Driver");
        });
    }
}
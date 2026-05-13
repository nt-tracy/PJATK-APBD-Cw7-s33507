using APBD_C07.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_C07.Infrastructure;

//class which represents talking session with database
public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{
    
    public DbSet<PCs> PCs { get; set; }
    public DbSet<PCComponents> PcComponents { get; set; }
    public DbSet<ComponentTypes> ComponentTypes { get; set; }
    public DbSet<Components> Components { get; set; }
    public DbSet<ComponentManufacturers> ComponentManufacturers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //adding seed data - min 3 records for each table
        // modelBuilder.Entity<PCs>().HasData([]);
        
        modelBuilder.Entity<PCs>().HasData([]);
    }
}
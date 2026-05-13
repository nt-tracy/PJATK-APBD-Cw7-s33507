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

        // 1. Dodawanie typów komponentów
        modelBuilder.Entity<ComponentTypes>().HasData(
            new ComponentTypes { Id = 1, Abbreviation = "CPU", Name = "Processor" },
            new ComponentTypes { Id = 2, Abbreviation = "GPU", Name = "Graphics Card" },
            new ComponentTypes { Id = 3, Abbreviation = "RAM", Name = "Memory" }
        );

        // 2. Dodawanie producentów
        modelBuilder.Entity<ComponentManufacturers>().HasData(
            new ComponentManufacturers
            {
                Id = 1, Abbreviation = "INTL", FullName = "Intel Corporation",
                FoundationDate = new DateTime(1968, 7, 18)
            },
            new ComponentManufacturers
            {
                Id = 2, Abbreviation = "NVDA", FullName = "NVIDIA Corporation",
                FoundationDate = new DateTime(1993, 4, 5)
            },
            new ComponentManufacturers
            {
                Id = 3, Abbreviation = "CRSL", FullName = "Corsair Components",
                FoundationDate = new DateTime(1994, 1, 1)
            }
        );

        // 3. Dodawanie komponentów (zależne od Type i Manufacturer)
        modelBuilder.Entity<Components>().HasData(
            new Components
            {
                Code = "CPU001", Name = "Core i9", Description = "High performance", ComponentManufacturersId = 1,
                ComponentTypesId = 1
            },
            new Components
            {
                Code = "GPU001", Name = "RTX 4090", Description = "Top tier graphics", ComponentManufacturersId = 2,
                ComponentTypesId = 2
            },
            new Components
            {
                Code = "RAM001", Name = "Vengeance 32GB", Description = "Fast DDR5", ComponentManufacturersId = 3,
                ComponentTypesId = 3
            }
        );

        // 4. Dodawanie komputerów
        modelBuilder.Entity<PCs>().HasData(
            new PCs
            {
                Id = 1, Name = "Gaming Beast X", Weight = 12.5f, Warranty = 36, CreatedAt = new DateTime(2026, 5, 8),
                Stock = 5
            },
            new PCs
            {
                Id = 2, Name = "Office Mini Pro", Weight = 4.2f, Warranty = 24, CreatedAt = new DateTime(2026, 4, 15),
                Stock = 12
            },
            new PCs
            {
                Id = 3, Name = "Workstation Z", Weight = 15.0f, Warranty = 48, CreatedAt = new DateTime(2026, 1, 10),
                Stock = 2
            }
        );

        // 5. Dodawanie relacji między PC a komponentami
        modelBuilder.Entity<PCComponents>().HasData(
            new PCComponents { PCId = 1, ComponentCode = "CPU001", Amount = 1 },
            new PCComponents { PCId = 1, ComponentCode = "GPU001", Amount = 1 },
            new PCComponents { PCId = 2, ComponentCode = "RAM001", Amount = 2 }
        );
    }
}
using InvenTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvenTracker.Infrastructure;

public class InvenTrackerDbContext : DbContext
{
    public DbSet<Company>  Companies { get; set; }
    public DbSet<Department>  Departments { get; set; }
    public DbSet<Drawer>  Drawers { get; set; }
    public DbSet<Item>  Items { get; set; }
    public DbSet<Wardrobe>  Wardrobes { get; set; }
    public DbSet<AddressCompany>  AddressCompanies { get; set; }
    public DbSet<AddressDepartment>  AddressDepartments { get; set; }

    public InvenTrackerDbContext(DbContextOptions<InvenTrackerDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Wyłącz CASCADE dla wszystkich relacji - żaden konflikt
        modelBuilder.Entity<Department>()
            .HasOne(x => x.Company)
            .WithMany(x => x.Departments)
            .HasForeignKey(x => x.CompanyId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<Department>()
            .HasOne(x=>x.Address)
            .WithOne(x=>x.Department)
            .HasForeignKey<AddressDepartment>(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Company>()
            .HasOne(x=>x.Address)
            .WithOne(x => x.Company)
            .HasForeignKey<AddressCompany>(x => x.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Wardrobe>()
            .HasOne(x => x.Company)
            .WithMany(x => x.Wardrobes)
            .HasForeignKey(x => x.CompanyId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Wardrobe>()
            .HasOne(x => x.Department)
            .WithMany(x => x.Wardrobes)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
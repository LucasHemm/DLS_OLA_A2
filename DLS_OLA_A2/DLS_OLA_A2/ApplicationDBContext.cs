using DLS_OLA_A2.Objects;
using Microsoft.EntityFrameworkCore;

namespace DLS_OLA_A2;

public class ApplicationDbContext : DbContext
{

    // Add DbSet properties here
    public DbSet<ChemicalBarrel> ChemicalBarrels { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Depot> Depots { get; set; }
    public DbSet<Staff> Staff { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Audit> Audits { get; set; }


    // Constructor that accepts DbContextOptions
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Constructor that accepts no arguments
    public ApplicationDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Only configure SQL Server if no options are provided (to avoid overriding options in tests)
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=dls_ola_a2;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
using Microsoft.EntityFrameworkCore;

namespace Application.Persistence.Database;

public class ApplicationContext : DbContext
{
    // public DbSet<ApplicationDao> Applications { get; set; }
    
    private const string DbName = "ApplicationDB";
        
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseInMemoryDatabase(DbName);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}
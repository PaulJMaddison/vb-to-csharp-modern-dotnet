using Microsoft.EntityFrameworkCore;

namespace DataAccessEfCore;

// VB6 note: DbContext is a modern replacement for hand-written ADO connection/recordset plumbing.
// EF Core tracks changes in memory, then saves them as one "unit of work" when SaveChanges is called.
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers => Set<Customer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customers");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name).HasMaxLength(100).IsRequired();
            entity.Property(c => c.Email).HasMaxLength(200).IsRequired();
            entity.HasIndex(c => c.Email).IsUnique();
        });
    }
}

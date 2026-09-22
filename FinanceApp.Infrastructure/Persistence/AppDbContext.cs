using FinanceApp.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<FinancialProfile> FinancialProfiles { get; set; }
    public DbSet<CreditCard> CreditCards { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Purchase>().HasKey(p => p.Id);
        modelBuilder.Entity<FinancialProfile>().HasKey(f => f.Id);
        modelBuilder.Entity<CreditCard>().HasKey(c => c.Id);
        modelBuilder.Entity<Category>().HasKey(c => c.Id);
    }
}
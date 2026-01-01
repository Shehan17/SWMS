using Microsoft.EntityFrameworkCore;
using SWMS.Models;

namespace SWMS.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<UserAccount> UserAccounts => Set<UserAccount>();
    public DbSet<Report> Reports => Set<Report>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure one-to-many relationship
        modelBuilder.Entity<Report>()
            .HasOne(r => r.UserAccount)
            .WithMany(u => u.Reports)
            .HasForeignKey(r => r.UserAccountId)
            .OnDelete(DeleteBehavior.Cascade); // optional
    }
}

using Microsoft.EntityFrameworkCore;
using UserAuthApp.Models;

namespace UserAuthApp;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-9PK656A\\SQLEXPRESS;Database=UserAuthDb;Trusted_Connection=True;TrustServerCertificate=True");
    }
}

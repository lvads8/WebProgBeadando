using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebProgBeadando.Models;

namespace WebProgBeadando.Data;

// = null! is required for NRT to shut up.
public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Achievement> Achievements { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
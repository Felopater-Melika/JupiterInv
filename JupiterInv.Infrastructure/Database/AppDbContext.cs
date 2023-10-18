using JupiterInv.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JupiterInv.Infrastructure.Database;

public class AppDbContext : IdentityDbContext<User, Role, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public new DbSet<User> Users { get; set; }
    public new DbSet<Role> Roles { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
}

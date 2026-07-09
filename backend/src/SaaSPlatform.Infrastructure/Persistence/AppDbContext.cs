using Microsoft.EntityFrameworkCore;
using SaaSPlatform.Domain.Entities;

namespace SaaSPlatform.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users => Set<User>();
    // public DbSet<Tenant> Tenants => Set<Tenant>();
    // public DbSet<TenantDomain> TenantDomains => Set<TenantDomain>();
    // public DbSet<TenantMembership> TenantMemberships => Set<TenantMembership>();
    // public DbSet<Role> Roles => Set<Role>();
    // public DbSet<Permission> Permissions => Set<Permission>();
    // public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    // public DbSet<OtpCode> OtpCodes => Set<OtpCode>();
    // public DbSet<Session> Sessions => Set<Session>();
    // public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
using E_Commerce.Domain.Abstraction;
using E_Commerce.Domain.Entities.UserAttributeEntities;
using GenericRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Persistance.Context;

public sealed class CommerceContext : IdentityDbContext<User,Role,int> , IUnitOfWork
{
    public CommerceContext(DbContextOptions options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);
        modelBuilder.Ignore<IdentityUserLogin<int>>();
        modelBuilder.Ignore<IdentityUserRole<int>>();
        modelBuilder.Ignore<IdentityUserClaim<int>>();
        modelBuilder.Ignore<IdentityUserToken<int>>();
        modelBuilder.Ignore<IdentityRoleClaim<int>>();
        modelBuilder.Ignore<IdentityRole<int>>();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entities = ChangeTracker.Entries<BaseEntity>();
        foreach (var entity in entities)
        {
            if (entity.State == EntityState.Added)
            {
                entity.Property(x => x.CreatedAt)
                    .CurrentValue = DateTime.UtcNow;
            }

            if (entity.State == EntityState.Modified)
            {
                entity.Property(x => x.UpdatedAt)
                    .CurrentValue = DateTime.UtcNow;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

}

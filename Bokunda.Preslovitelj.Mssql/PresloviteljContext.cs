using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bokunda.Preslovitelj.Domain;
public class PresloviteljContext : DbContext
{
    private readonly IConfiguration _configuration;

    public PresloviteljContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && e.State is EntityState.Added or EntityState.Modified);

        foreach (var entityEntry in entries)
        {
            ((BaseEntity)entityEntry.Entity).SetUpdatedOn(DateTimeOffset.Now);

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).SetCreatedOn(DateTimeOffset.Now);
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<TranslationRequest> TranslationRequests { get; set; }
    public DbSet<TranslationResponse> TranslationResponses { get; set; }
}

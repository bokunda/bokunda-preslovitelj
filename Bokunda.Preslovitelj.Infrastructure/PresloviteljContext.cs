using Bokunda.Preslovitelj.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bokunda.Preslovitelj.Infrastructure;
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

    public DbSet<TranslationRequest> TranslationRequests { get; set; }
    public DbSet<TranslationResponse> TranslationResponses { get; set; }
}

using Microsoft.EntityFrameworkCore;

namespace Bokunda.Preslovitelj.Context;
public class PresloviteljDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public PresloviteljDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<TranslationTex> Students { get; set; }
}

using Jevstafjev.Anecdotes.AnecdoteApi.Infrastructure;
using Jevstafjev.Anecdotes.AnecdoteApi.Web.Definitions.Base;
using Microsoft.EntityFrameworkCore;

namespace Jevstafjev.Anecdotes.AnecdoteApi.Web.Definitions.DbContext;

public class DbContextDefinition : AppDefinition
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString(nameof(ApplicationDbContext));
            options.UseSqlServer(connectionString);
        });
    }
}

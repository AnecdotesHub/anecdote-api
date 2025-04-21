using Jevstafjev.Anecdotes.AnecdoteApi.Domain;
using Jevstafjev.Anecdotes.AnecdoteApi.Web.Definitions.Base;

namespace Jevstafjev.Anecdotes.AnecdoteApi.Web.Definitions.Cors;

public class CorsDefinition : AppDefinition
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        var origins = builder.Configuration.GetSection("Cors").GetSection("Origins").Value?.Split(',');
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(AppData.PolicyCorsName, policyBuilder =>
            {
                policyBuilder.AllowAnyHeader();
                policyBuilder.AllowAnyMethod();

                if (origins is not { Length: > 0 })
                {
                    return;
                }

                if (origins.Contains("*"))
                {
                    policyBuilder.AllowAnyHeader();
                    policyBuilder.AllowAnyMethod();
                    policyBuilder.SetIsOriginAllowed(host => true);
                    policyBuilder.AllowCredentials();
                }
                else
                {
                    foreach (var origin in origins)
                    {
                        policyBuilder.WithOrigins(origin);
                    }
                }
            });
        });
    }
}

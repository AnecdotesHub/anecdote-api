using Jevstafjev.Anecdotes.AnecdoteApi.Web.Definitions.Base;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Jevstafjev.Anecdotes.AnecdoteApi.Web.Definitions.Swagger;

public class SwaggerDefinition : AppDefinition
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "AnecdoteApi",
                Version = "1.0.0"
            });
        });
    }

    public override void ConfigureApplication(WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            return;
        }

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "AnecdoteApi v1.0.0");
            options.DocumentTitle = "AnecdoteApi";
            options.DefaultModelExpandDepth(0);
            options.DefaultModelRendering(ModelRendering.Model);
            options.DefaultModelsExpandDepth(0);
            options.DocExpansion(DocExpansion.None);
        });
    }
}

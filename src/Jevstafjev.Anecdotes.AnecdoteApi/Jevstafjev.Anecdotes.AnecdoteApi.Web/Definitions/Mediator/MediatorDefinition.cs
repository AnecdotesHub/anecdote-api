using Jevstafjev.Anecdotes.AnecdoteApi.Web.Definitions.Base;

namespace Jevstafjev.Anecdotes.AnecdoteApi.Web.Definitions.Mediator;

public class MediatorDefinition : AppDefinition
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<Program>());
    }
}

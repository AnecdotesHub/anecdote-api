using Jevstafjev.Anecdotes.AnecdoteApi.Web.Application.Services;
using Jevstafjev.Anecdotes.AnecdoteApi.Web.Definitions.Base;

namespace Jevstafjev.Anecdotes.AnecdoteApi.Web.Definitions.DependencyContainer;

public class ContainerDefinition : AppDefinition
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ITagService, TagService>();
    }
}

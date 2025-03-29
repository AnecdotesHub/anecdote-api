using Jevstafjev.Anecdotes.AnecdoteApi.Web.Definitions.Base;
using Jevstafjev.Anecdotes.AnecdoteApi.Web.Definitions.FluentValidation;
using MediatR;

namespace Jevstafjev.Anecdotes.AnecdoteApi.Web.Definitions.Mediator;

public class MediatorDefinition : AppDefinition
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
        builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<Program>());
    }
}

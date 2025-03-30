using Jevstafjev.Anecdotes.AnecdoteApi.Domain;
using Jevstafjev.Anecdotes.AnecdoteApi.Web.Application.Messaging.TagMessages.Queries;
using Jevstafjev.Anecdotes.AnecdoteApi.Web.Definitions.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jevstafjev.Anecdotes.AnecdoteApi.Web.Endpoints;

public class TagEndpoints : AppDefinition
{
    public override void ConfigureApplication(WebApplication app)
    {
        app.MapTagEndpoints();
    }
}

internal static class TagEndpointsExtensions
{
    public static void MapTagEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/tags/").WithTags(nameof(Tag));

        group.MapGet("get-list", async ([FromServices] IMediator mediator, HttpContext context) =>
            await mediator.Send(new TagGetListRequest(), context.RequestAborted))
            .Produces(200)
            .WithOpenApi();
    }
}

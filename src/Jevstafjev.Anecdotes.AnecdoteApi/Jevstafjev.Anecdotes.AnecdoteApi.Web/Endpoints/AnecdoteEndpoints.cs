using Jevstafjev.Anecdotes.AnecdoteApi.Domain;
using Jevstafjev.Anecdotes.AnecdoteApi.Web.Application.Messaging.AnecdoteMessages.Queries;
using Jevstafjev.Anecdotes.AnecdoteApi.Web.Definitions.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jevstafjev.Anecdotes.AnecdoteApi.Web.Endpoints
{
    public class AnecdoteEndpoints : AppDefinition
    {
        public override void ConfigureApplication(WebApplication app)
        {
            app.MapAnecdoteEndpoints();
        }
    }
    
    internal static class AnecdoteEndpointsExtensions
    {
        public static void MapAnecdoteEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/anecdotes/").WithTags(nameof(Anecdote));

            group.MapGet("paged/{pageIndex:int}", async ([FromServices] IMediator mediator,
                HttpContext context,
                int pageIndex,
                int pageSize = 10) =>
                await mediator.Send(new AnecdoteGetPagedRequest(pageIndex, pageSize, context.User), context.RequestAborted))
                .Produces(200)
                .WithOpenApi();
        }
    }
}

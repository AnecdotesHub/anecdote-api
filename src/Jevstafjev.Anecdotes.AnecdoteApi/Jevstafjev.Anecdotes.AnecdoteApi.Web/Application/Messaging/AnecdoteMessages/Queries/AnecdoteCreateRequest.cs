using Arch.EntityFrameworkCore.UnitOfWork;
using Ardalis.Result;
using AutoMapper;
using Duende.IdentityModel.Client;
using Jevstafjev.Anecdotes.AnecdoteApi.Domain;
using Jevstafjev.Anecdotes.AnecdoteApi.Web.Application.Messaging.AnecdoteMessages.ViewModels;
using Jevstafjev.Anecdotes.AnecdoteApi.Web.Application.Services;
using MediatR;
using System.Security.Claims;

namespace Jevstafjev.Anecdotes.AnecdoteApi.Web.Application.Messaging.AnecdoteMessages.Queries;

public record AnecdoteCreateRequest(AnecdoteCreateViewModel Model, ClaimsPrincipal User) : IRequest<Result<AnecdoteViewModel>>;

public class AnecdoteCreateRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, ITagService tagService, IHttpClientFactory httpClientFactory, IConfiguration configuration)
    : IRequestHandler<AnecdoteCreateRequest, Result<AnecdoteViewModel>>
{
    public async Task<Result<AnecdoteViewModel>> Handle(AnecdoteCreateRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Anecdote>();

        var entity = mapper.Map<Anecdote>(request.Model, o => o.Items[ClaimTypes.Name] = request.User.Identity!.Name);

        var additionResult = await tagService.AddTagsAsync(
            entity,
            request.Model.Tags.Split(new[] { ',', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries).ToList());
        if (!additionResult.IsSuccess)
        {
            return Result.Invalid(new ValidationError(additionResult.Exception!.Message));
        }

        await repository.InsertAsync(entity);
        await unitOfWork.SaveChangesAsync();

        var mapped = mapper.Map<AnecdoteViewModel>(entity);

        var authClient = httpClientFactory.CreateClient();
        var discoveryDocument = await authClient.GetDiscoveryDocumentAsync(configuration["AuthServer:Url"]);
        var tokenResponse = await authClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
        {
            Address = discoveryDocument.TokenEndpoint,
            ClientId = "anecdote-service-client",
            ClientSecret = "secret",
            Scope = "Notification"
        });

        var notificationClient = httpClientFactory.CreateClient();
        notificationClient.SetBearerToken(tokenResponse.AccessToken!);

        var result = await notificationClient.PostAsJsonAsync($"{configuration["ServiceUrls:Notification"]}/api/delivery/send-to-all", mapped);

        return Result<AnecdoteViewModel>.Success(mapped);
    }
}

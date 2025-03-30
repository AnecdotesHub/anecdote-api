using Arch.EntityFrameworkCore.UnitOfWork;
using Ardalis.Result;
using AutoMapper;
using Jevstafjev.Anecdotes.AnecdoteApi.Domain;
using Jevstafjev.Anecdotes.AnecdoteApi.Web.Application.Messaging.TagMessages.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jevstafjev.Anecdotes.AnecdoteApi.Web.Application.Messaging.TagMessages.Queries;

public record TagGetListRequest : IRequest<Result<List<TagViewModel>>>;

public class TagGetListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<TagGetListRequest, Result<List<TagViewModel>>>
{
    public Task<Result<List<TagViewModel>>> Handle(TagGetListRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<Tag>();

        var entities = repository.GetAll()
            .Include(x => x.Anecdotes)
            .IgnoreAutoIncludes()
            .OrderBy(x => x.Name);

        var mapped = mapper.Map<List<TagViewModel>>(entities);
        return Task.FromResult(Result.Success(mapped));
    }
}

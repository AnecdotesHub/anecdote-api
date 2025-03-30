using AutoMapper;
using Jevstafjev.Anecdotes.AnecdoteApi.Domain;
using Jevstafjev.Anecdotes.AnecdoteApi.Web.Application.Messaging.TagMessages.ViewModels;

namespace Jevstafjev.Anecdotes.AnecdoteApi.Web.Application.Messaging.TagMessages;

public class TagMapperConfiguration : Profile
{
    public TagMapperConfiguration()
    {
        CreateMap<Tag, TagViewModel>()
            .ForMember(x => x.AnecdotesCount, o => o.MapFrom(x => x.Anecdotes!.Count));
    }
}

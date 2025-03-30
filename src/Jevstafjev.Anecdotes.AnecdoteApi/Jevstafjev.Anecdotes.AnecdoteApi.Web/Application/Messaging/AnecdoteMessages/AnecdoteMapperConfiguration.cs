using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using AutoMapper;
using Jevstafjev.Anecdotes.AnecdoteApi.Web.Application.Messaging.AnecdoteMessages.ViewModels;
using Jevstafjev.Anecdotes.AnecdoteApi.Domain;
using Jevstafjev.Anecdotes.AnecdoteApi.Web.Definitions.Mapping;

namespace Jevstafjev.Anecdotes.AnecdoteApi.Web.Application.Messaging.AnecdoteMessages;

public class AnecdoteMapperConfiguration : Profile
{
    public AnecdoteMapperConfiguration()
    {
        CreateMap<Anecdote, AnecdoteViewModel>();

        CreateMap<IPagedList<Anecdote>, IPagedList<AnecdoteViewModel>>()
            .ConvertUsing<PagedListConverter<Anecdote, AnecdoteViewModel>>();
    }
}

namespace Jevstafjev.Anecdotes.AnecdoteApi.Web.Application.Messaging.TagMessages.ViewModels;

public class TagViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int AnecdotesCount { get; set; }
}

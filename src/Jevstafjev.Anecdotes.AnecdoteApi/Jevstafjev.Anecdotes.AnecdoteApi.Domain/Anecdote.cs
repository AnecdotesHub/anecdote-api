using Jevstafjev.Anecdotes.AnecdoteApi.Domain.Base;

namespace Jevstafjev.Anecdotes.AnecdoteApi.Domain;

public class Anecdote : Auditable
{
    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public virtual List<Tag>? Tags { get; set; }
}

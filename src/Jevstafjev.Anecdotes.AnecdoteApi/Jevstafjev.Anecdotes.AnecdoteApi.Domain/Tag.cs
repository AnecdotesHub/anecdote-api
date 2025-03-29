using Jevstafjev.Anecdotes.AnecdoteApi.Domain.Base;

namespace Jevstafjev.Anecdotes.AnecdoteApi.Domain;

public class Tag : Identity
{
    public string Name { get; set; } = null!;

    public virtual List<Anecdote>? Anecdotes { get; set; }
}

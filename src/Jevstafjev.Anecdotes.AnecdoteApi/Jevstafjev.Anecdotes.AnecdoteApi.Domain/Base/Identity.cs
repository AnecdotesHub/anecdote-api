namespace Jevstafjev.Anecdotes.AnecdoteApi.Domain.Base;

public class Identity : IHaveId
{
    public Guid Id { get; set; }
}

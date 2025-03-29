namespace Jevstafjev.Anecdotes.AnecdoteApi.Domain.Base;

public interface IAuditable
{
    DateTime CreatedAt { get; set; }

    string CreatedBy { get; set; }

    DateTime? UpdatedAt { get; set; }

    string? UpdatedBy { get; set; }
}

using Jevstafjev.Anecdotes.AnecdoteApi.Domain;
using Jevstafjev.Anecdotes.AnecdoteApi.Infrastructure.Base;
using Microsoft.EntityFrameworkCore;

namespace Jevstafjev.Anecdotes.AnecdoteApi.Infrastructure;

public class ApplicationDbContext : DbContextBase
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Anecdote> Anecdotes { get; set; }

    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Anecdote>().Navigation(x => x.Tags).AutoInclude();
    }
}

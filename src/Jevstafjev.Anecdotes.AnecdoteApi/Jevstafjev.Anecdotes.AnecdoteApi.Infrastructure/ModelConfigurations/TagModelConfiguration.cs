using Jevstafjev.Anecdotes.AnecdoteApi.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Jevstafjev.Anecdotes.AnecdoteApi.Infrastructure.ModelConfigurations;

public class TagModelConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(128).IsRequired();

        builder.HasMany(x => x.Anecdotes);
    }
}

using DddCleanArchitecture.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DddCleanArchitecture.Infrastructure.Database.Configurations;

public sealed class CommentConfiguration
    : DbEntityConfiguration<CommentEntity>
{
    protected override void InternalConfigure(EntityTypeBuilder<CommentEntity> builder)
    {
        builder.ToTable(nameof(CommentEntity));

        builder
            .Property(static x => x.Content)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(static x => x.CreatedOn)
            .IsRequired();
    }
}
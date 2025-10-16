using DddCleanArchitecture.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DddCleanArchitecture.Infrastructure.Database.Configurations;

public sealed class CommentConfiguration
    : DbEntityConfiguration<Comment>
{
    protected override void InternalConfigure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable(nameof(Comment));
        
        builder
            .Property(static x => x.Content)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(static x => x.CreatedOn)
            .IsRequired();
    }
}
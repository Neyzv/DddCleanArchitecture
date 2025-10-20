using DddCleanArchitecture.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DddCleanArchitecture.Infrastructure.Database.Configurations;

public sealed class ArticleConfiguration
    : DbEntityConfiguration<Article>
{
    protected override void InternalConfigure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable(nameof(Article));

        builder.Property(static x => x.Title)
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(static x => x.Content)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(static x => x.PublishDate)
            .IsRequired();

        builder
            .HasMany(static x => x.Comments)
            .WithOne()
            .HasForeignKey(static x => x.ArticleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(static x => x.Comments)
            .AutoInclude(false);
    }
}
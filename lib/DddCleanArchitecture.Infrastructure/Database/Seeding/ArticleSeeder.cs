using Bogus;
using DddCleanArchitecture.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DddCleanArchitecture.Infrastructure.Database.Seeding;

public sealed class ArticleSeeder
    : ISeeder
{
    /// <inheritdoc />
    public bool ShouldBeApplied(DbContext context) =>
        !context.Set<ArticleEntity>().Any();

    /// <summary>
    /// Generate random articles with their comments.
    /// </summary>
    /// <returns>The newly created articles.</returns>
    private static List<ArticleEntity> GenerateArticles()
    {
        var commentFaker = new Faker<CommentEntity>()
            .RuleFor(static x => x.Content, static x => x.Lorem.Sentence(4, 16));

        var faker = new Faker<ArticleEntity>()
            .RuleFor(static x => x.Title, static x => x.Lorem.Sentence(x.Random.Int(1, 4)))
            .RuleFor(static x => x.Content, static x => x.Lorem.Paragraphs(x.Random.Int(1, 3)))
            .RuleFor(static x => x.PublishDate, static x => x.Date.Recent(60))
            .RuleFor(a => a.Comments, (f, a) =>
            {
                var count = f.Random.Int(0, 8);
                var comments = commentFaker.Generate(count);

                foreach (var c in comments)
                {
                    c.CreatedOn = a.PublishDate.AddMinutes(f.Random.Int(1, 10000));
                }

                return comments;
            });

        return faker.Generate(Random.Shared.Next(3, 6));
    }

    /// <inheritdoc />
    public void Seed(DbContext context)
    {
        context.Set<ArticleEntity>().AddRange(GenerateArticles());
        context.SaveChanges();
    }

    /// <inheritdoc />
    public async Task<bool> ShouldBeAppliedAsync(DbContext context, CancellationToken token) =>
        !await context.Set<ArticleEntity>().AnyAsync(token).ConfigureAwait(false);

    /// <inheritdoc />
    public async Task SeedAsync(DbContext context, CancellationToken token)
    {
        await context
            .Set<ArticleEntity>()
            .AddRangeAsync(GenerateArticles(), token)
            .ConfigureAwait(false);

        await context.SaveChangesAsync(token).ConfigureAwait(false);
    }
}
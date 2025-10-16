using Bogus;
using DddCleanArchitecture.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DddCleanArchitecture.Infrastructure.Database.Seeding;

public sealed class ArticleSeeder
    : ISeeder
{
    public bool ShouldBeApplied(DbContext context) =>
        context.Set<Article>().Any();

    private List<Article> GenerateArticles()
    {
        var commentFaker = new Faker<Comment>()
            .RuleFor(static x => x.Content, static x => x.Lorem.Sentence(4, 16));
        
        var faker = new Faker<Article>()
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

    public void Seed(DbContext context)
    {
        context.Set<Article>().AddRange(GenerateArticles());
        context.SaveChanges();
    }

    public Task<bool> ShouldBeAppliedAsync(DbContext context, CancellationToken token) =>
        context.Set<Article>().AnyAsync(token);

    public async Task SeedAsync(DbContext context, CancellationToken token)
    {
        await context
            .Set<Article>()
            .AddRangeAsync(GenerateArticles(), token)
            .ConfigureAwait(false);
        
        await context.SaveChangesAsync(token).ConfigureAwait(false);
    }
}
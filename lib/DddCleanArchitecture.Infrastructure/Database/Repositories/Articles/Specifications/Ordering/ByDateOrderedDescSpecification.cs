﻿using System.Linq.Expressions;
using DddCleanArchitecture.Infrastructure.Database.Models;
using DddCleanArchitecture.Infrastructure.Database.Repositories.Specifications;

namespace DddCleanArchitecture.Infrastructure.Database.Repositories.Articles.Specifications.Ordering;

public sealed class ByDateOrderedDescSpecification
    : IOrderedDescSpecification<Article>
{
    public Expression<Func<Article, object>> OrderByDescending =>
        x => x.PublishDate;
}
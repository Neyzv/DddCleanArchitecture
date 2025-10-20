﻿using DddCleanArchitecture.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DddCleanArchitecture.Infrastructure.Database.Repositories.Specifications;

internal static class SpecificationEvaluator
{
    internal static IQueryable<TDbEntity> GetQuery<TDbEntity>(this IQueryable<TDbEntity> baseQuery,
        params IEnumerable<ISpecification<TDbEntity>> specifications)
        where TDbEntity : class, IDbEntity
    {
        var query = baseQuery;

        var orderBySpecifications = new List<ISpecification<TDbEntity>>();

        foreach (var specification in specifications)
        {
            switch (specification)
            {
                case ICriteriaSpecification<TDbEntity> criteriaSpecification:
                    query = query.Where(criteriaSpecification.Criteria);
                    break;

                case IOrderedSpecification<TDbEntity> or IOrderedDescSpecification<TDbEntity>:
                    orderBySpecifications.Add(specification);
                    break;

                case IIncludeSpecification<TDbEntity> includeSpecification:
                    query = query.Include(includeSpecification.Include);
                    break;

                default:
                    continue;
            }
        }

        if (orderBySpecifications.Count is 0)
            return query;

        var orderedQuery = orderBySpecifications[0] switch
        {
            IOrderedSpecification<TDbEntity> orderedSpecification => query.OrderBy(orderedSpecification.OrderBy),
            IOrderedDescSpecification<TDbEntity> orderedDescSpecification => query.OrderByDescending(orderedDescSpecification.OrderByDescending),
            _ => throw new InvalidOperationException()
        };

        for (var i = 1; i < orderBySpecifications.Count; i++)
        {
            orderedQuery = orderBySpecifications[i] switch
            {
                IOrderedSpecification<TDbEntity> orderedSpecification => orderedQuery.ThenBy(orderedSpecification.OrderBy),
                IOrderedDescSpecification<TDbEntity> orderedDescSpecification => orderedQuery.ThenByDescending(orderedDescSpecification.OrderByDescending),
                _ => throw new InvalidOperationException()
            };
        }

        query = orderedQuery;

        return query;
    }
}
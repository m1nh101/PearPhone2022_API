using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Helpers;

public static class Query
{
    private static IQueryable<T> Source<T>(IQueryable<T> source, bool asNoTracking)
        where T : class
    {
        return asNoTracking ? source.AsNoTracking() : source;
    }

    public static IQueryable<T> All<T>(this IQueryable<T> source,
        ISpecification<T> spec,
        bool asNoTracking = true)
        where T : class
    {
        IQueryable<T> result = Source(source, asNoTracking);

        result = result.Where(spec.Criteria);

        result = spec.Includes.Aggregate(result, (current, expression) => 
            expression(current));

        if(spec.OrderBy != null)
            result = result.OrderBy(spec.OrderBy);

        if(spec.OrderByDescending != null)
            result = result.OrderByDescending(spec.OrderByDescending);

        return result;
    }

    public static T Get<T>(this IQueryable<T> source,
        ISpecification<T> spec,
        bool asNoTracking = true)
        where T : class
    {
        IQueryable<T> data = Source(source, asNoTracking);

        _ = spec.Includes.Aggregate(data, (current, expr) => expr(current));

        var result = data.FirstOrDefault(spec.Criteria);
        
        if(result == null)
            throw new NullReferenceException($"no entity found");

        return result; 
    }
}
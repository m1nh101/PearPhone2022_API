using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Helpers;

public enum QueryState
{
  Tracking,
  NoTracking
}

public static class Query
{
  private static IQueryable<T> Source<T>(IQueryable<T> source, QueryState state)
      where T : class
  {
    return state == QueryState.NoTracking ? source.AsNoTracking() : source;
  }

  public static IQueryable<T> All<T>(this IQueryable<T> source,
      ISpecification<T> spec,
      QueryState state)
      where T : class
  {
    IQueryable<T> result = Source(source, state);

    result = result.Where(spec.Criteria);

    result = spec.Includes.Aggregate(result, (current, expression) =>
        expression(current));

    if (spec.OrderBy != null)
      result = result.OrderBy(spec.OrderBy);

    if (spec.OrderByDescending != null)
      result = result.OrderByDescending(spec.OrderByDescending);

    return result;
  }

  public static async Task<T> Find<T>(this IQueryable<T> source,
      ISpecification<T> spec,
      QueryState state)
      where T : class
  {
    IQueryable<T> data = Source(source, state);

    data = spec.Includes.Aggregate(data, (current, expr) => expr(current));

    var result = await data.FirstOrDefaultAsync(spec.Criteria);

    if (result == null)
      throw new NullReferenceException($"no entity found");

    return result;
  }
}
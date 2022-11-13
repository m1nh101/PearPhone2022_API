using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Interfaces;

public interface ISpecification<T>
{
  Expression<Func<T, bool>> Criteria { get; }
  List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> Includes { get; }
  Expression<Func<T, object>> OrderBy { get; }
  Expression<Func<T, object>> OrderByDescending { get; }
}

public class Specification<T> : ISpecification<T>
{
  public Specification(Expression<Func<T, bool>> criteria)
  {
    Criteria = criteria;
  }

  public Expression<Func<T, bool>> Criteria { get; private set; }

  public List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> Includes { get; } = new();

  public Expression<Func<T, object>> OrderBy { get; private set; } = null!;

  public Expression<Func<T, object>> OrderByDescending { get; private set; } = null!;

  public void AddInclude(Func<IQueryable<T>, IIncludableQueryable<T, object>> expression) => Includes.Add(expression);

  public void SetOrderBy(Expression<Func<T, object>> expression) => OrderBy = expression;

  public void SetOrderByDescending(Expression<Func<T, object>> expression) => OrderByDescending = expression;
}
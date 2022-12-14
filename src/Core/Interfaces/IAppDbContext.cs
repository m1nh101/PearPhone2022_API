using Core.Entities.Orders;
using Core.Entities.Stocks;
using Microsoft.EntityFrameworkCore;

namespace Core.Interfaces;

public interface IAppDbContext
{
  DbSet<Order> Orders { get; }
  DbSet<Stock> Stocks { get; }
  DbSet<Branch> Branches { get; }
  Task<int> Commit();
}

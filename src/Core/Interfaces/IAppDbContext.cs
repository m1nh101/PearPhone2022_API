using Core.Entities;
using Core.Entities.Orders;
using Core.Entities.Phones;
using Microsoft.EntityFrameworkCore;

namespace Core.Interfaces;

public interface IAppDbContext
{
  DbSet<Order> Orders { get; }
  DbSet<Stock> Stocks { get; }
  DbSet<Sale> Sales { get; }
  DbSet<Branch> Branches { get; }
  DbSet<Phone> Phones { get; }
  Task<int> Commit();
}
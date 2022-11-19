using Core.Entities;
using Core.Entities.Orders;
using Core.Entities.Payments;
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
  public DbSet<Voucher> Vouchers { get; }
  public DbSet<Receipt> Receipts { get; }
  Task<int> Commit();
}
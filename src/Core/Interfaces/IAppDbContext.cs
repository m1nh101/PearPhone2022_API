using Core.Entities;
using Core.Entities.Orders;
using Core.Entities.Payments;
using Core.Entities.Phones;
using Core.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Core.Interfaces;

public interface IAppDbContext
{
  DbSet<Order> Orders { get; }
  DbSet<Stock> Stocks { get; }
  DbSet<Sale> Sales { get; }
  DbSet<Phone> Phones { get; }
  public DbSet<Voucher> Vouchers { get; }
  public DbSet<ShippingAddress> ShippingAddress { get; }
  public DbSet<Receipt> Receipts { get; }
  Task<int> Commit();
}
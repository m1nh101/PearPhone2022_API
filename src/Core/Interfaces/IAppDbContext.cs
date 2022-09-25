using Core.Entities.Orders;
using Core.Entities.Stocks;
using Core.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Core.Interfaces;

public interface IAppDbContext
{
  DbSet<Order> Orders { get; }
  DbSet<Stock> Stocks { get; }
}

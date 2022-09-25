using Core.Entities.Orders;
using Core.Entities.Stocks;
using Core.Entities.Users;
using Core.Interfaces;
using Infrastructure.Database.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class AppDbContext : IdentityDbContext<User>, IAppDbContext
{

  public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.ApplyConfiguration(new ShippingAddressEntityConfiguration());
    builder.ApplyConfiguration(new SaleEntityConfiguration());
    builder.ApplyConfiguration(new ColorEntityConfiguration());
    builder.ApplyConfiguration(new BranchEntityConfiguration());
    builder.ApplyConfiguration(new PhoneEntityConfiguration());
    builder.ApplyConfiguration(new PhoneDetailEntityConfiguration());
    builder.ApplyConfiguration(new OrderEntityConfiguration());
    builder.ApplyConfiguration(new ReceiptEntityConfiguration());
    builder.ApplyConfiguration(new ItemEntityConfiguration());
    builder.ApplyConfiguration(new ImageEntityConfiguration());

    base.OnModelCreating(builder);
  }

  /// <summary>
  /// get Order collection
  /// </summary>
  public DbSet<Order> Orders => Set<Order>();

  /// <summary>
  /// get stock collection
  /// </summary>
  public DbSet<Stock> Stocks => throw new NotImplementedException();
}
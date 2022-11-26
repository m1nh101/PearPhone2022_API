using Core.Entities;
using Core.Entities.Orders;
using Core.Entities.Payments;
using Core.Entities.Phones;
using Core.Entities.Users;
using Core.Interfaces;
using Infrastructure.Database.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.Bases;

namespace Infrastructure.Database;

public class AppDbContext : IdentityDbContext<User>, IAppDbContext
{
  private readonly ICurrentUser _user;

  public AppDbContext(DbContextOptions<AppDbContext> options, ICurrentUser user) : base(options)
  {
    _user = user;
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.ApplyConfiguration(new ShippingAddressEntityConfiguration());
    builder.ApplyConfiguration(new SaleEntityConfiguration());
    builder.ApplyConfiguration(new ColorEntityConfiguration());
    builder.ApplyConfiguration(new PhoneEntityConfiguration());
    builder.ApplyConfiguration(new PhoneDetailEntityConfiguration());
    builder.ApplyConfiguration(new OrderEntityConfiguration());
    builder.ApplyConfiguration(new ReceiptEntityConfiguration());
    builder.ApplyConfiguration(new ItemEntityConfiguration());
    builder.ApplyConfiguration(new ImageEntityConfiguration());
    builder.ApplyConfiguration(new VoucherEntityConfiguration());

    base.OnModelCreating(builder);
  }

  public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    foreach(var entry in ChangeTracker.Entries<ModifierEntity>())
    {
      if(entry.State == EntityState.Added)
      {
        entry.Entity.CreatedBy = _user.Id;
        entry.Entity.UpdatedBy = _user.Id;
        entry.Entity.CreatedAt = DateTime.Now;
        entry.Entity.UpdatedAt = DateTime.Now;
      }

      if(entry.State == EntityState.Modified)
      {
        entry.Entity.UpdatedBy = _user.Id;
        entry.Entity.UpdatedAt = DateTime.Now;
      }
    }

    return base.SaveChangesAsync(cancellationToken);
  }

  public Task<int> Commit() => SaveChangesAsync();

  public DbSet<Order> Orders => Set<Order>();
  public DbSet<Stock> Stocks => Set<Stock>();
  public DbSet<Phone> Phones => Set<Phone>();
  public DbSet<Voucher> Vouchers => Set<Voucher>();
  public DbSet<Receipt> Receipts => Set<Receipt>();
  public DbSet<Sale> Sales => Set<Sale>();
}
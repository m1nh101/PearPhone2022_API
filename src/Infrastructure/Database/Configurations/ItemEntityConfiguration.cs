using Core.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class ItemEntityConfiguration : BaseModifierConfiguration<Item>
{
  public override void Configure(EntityTypeBuilder<Item> builder)
  {
    builder.ToTable("Items");

    builder.HasOne(e => e.Order)
      .WithMany(e => e.Items)
      .HasForeignKey(e => e.OrderId);

    builder.HasOne(e => e.Stock)
      .WithMany(e => e.Items)
      .HasForeignKey(e => e.StockId);
    
    base.Configure(builder);
  }
}
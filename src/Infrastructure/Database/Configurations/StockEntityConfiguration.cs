using Core.Entities.Phones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Bases;

namespace Infrastructure.Database.Configurations;

public class StockEntityConfiguration : BaseModifierConfiguration<Stock>
{
  public override void Configure(EntityTypeBuilder<Stock> builder)
  {
    builder.Ignore(e => e.SalePrice);

    builder.Property(e => e.Quantity)
      .HasColumnType("bigint");

    builder.HasOne(e => e.Color)
      .WithMany(e => e.Stocks)
      .HasForeignKey(e => e.ColorId);

    builder.HasOne(e => e.Phone)
      .WithMany(e => e.Stocks)
      .HasForeignKey(e => e.PhoneId);

    builder.Property(e => e.Price)
      .HasColumnType<double>("money");

    base.Configure(builder);
  }
}
using Core.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class OrderEntityConfiguration : BaseModifierConfiguration<Order>
{
  public override void Configure(EntityTypeBuilder<Order> builder)
  {
    builder.ToTable("Orders");

    base.Configure(builder);
  }
}
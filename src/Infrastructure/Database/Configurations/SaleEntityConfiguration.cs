using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class SaleEntityConfiguration : BaseModifierConfiguration<Sale>
{
  public override void Configure(EntityTypeBuilder<Sale> builder)
  {
    builder.ToTable("Sales");

    builder.Property(e => e.Discount).HasColumnType("real");

    base.Configure(builder);
  }
}
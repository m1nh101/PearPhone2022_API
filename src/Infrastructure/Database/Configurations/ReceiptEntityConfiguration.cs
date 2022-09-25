using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class ReceiptEntityConfiguration : BaseModifierConfiguration<Receipt>
{
  public override void Configure(EntityTypeBuilder<Receipt> builder)
  {
    builder.ToTable("Receipts");

    builder.HasOne(e => e.Address)
      .WithMany(e => e.Receipts)
      .HasForeignKey(e => e.AddressId);

    builder.HasOne(e => e.Order)
      .WithOne(e => e.Receipt)
      .HasForeignKey<Receipt>(e => e.OrderId)
      .OnDelete(DeleteBehavior.NoAction);

    base.Configure(builder);
  }
}
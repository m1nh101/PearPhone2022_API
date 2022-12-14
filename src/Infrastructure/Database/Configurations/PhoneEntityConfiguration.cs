using Core.Entities.Stocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class PhoneEntityConfiguration : BaseModifierConfiguration<Phone>
{
  public override void Configure(EntityTypeBuilder<Phone> builder)
  {
    builder.ToTable("Phones");

    builder.Property(e => e.Name)
      .HasMaxLength(1000)
      .HasColumnType("nvarchar")
      .IsRequired();

    builder.HasOne(e => e.Sale)
      .WithMany(e => e.Phones)
      .HasForeignKey(e => e.SaleId);

    builder.HasOne(e => e.Branch)
      .WithMany(e => e.Phones)
      .HasForeignKey(e => e.BranchId);

    base.Configure(builder);
  }
}
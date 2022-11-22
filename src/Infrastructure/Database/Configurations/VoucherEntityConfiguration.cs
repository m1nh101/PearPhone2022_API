using Core.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class VoucherEntityConfiguration : BaseModifierConfiguration<Voucher>
{
  public override void Configure(EntityTypeBuilder<Voucher> builder)
  {
    builder.ToTable("Vouchers");

    builder.HasIndex(e => e.Code).IsUnique();

    base.Configure(builder);
  }
}
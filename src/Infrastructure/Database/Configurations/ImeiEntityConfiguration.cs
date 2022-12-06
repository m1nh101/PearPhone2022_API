using Core.Entities.Phones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class ImeiEntityConfiguration : BaseEntityConfiguration<IMEI>
{
  public override void Configure(EntityTypeBuilder<IMEI> builder)
  {
    builder.ToTable("IMEIS");

    builder.HasOne(e => e.Stock)
      .WithMany(e => e.IMEIs)
      .HasForeignKey(e => e.StockId);

    builder.Property(e => e.Value).IsRequired();

    base.Configure(builder);
  }
}
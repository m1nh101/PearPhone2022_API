using Core.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class ShippingAddressEntityConfiguration : BaseModifierConfiguration<ShippingAddress>
{
  public override void Configure(EntityTypeBuilder<ShippingAddress> builder)
  {
    builder.ToTable("Addresses");

    builder.Property(e => e.Address)
      .HasMaxLength(1000)
      .HasColumnType("nvarchar")
      .IsRequired();

    builder.HasOne(e => e.User)
      .WithMany(e => e.Addresses)
      .HasForeignKey(e => e.UserId);

    base.Configure(builder);
  }
}
using Core.Entities.Phones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class PhoneDetailEntityConfiguration : BaseEntityConfiguration<PhoneDetail>
{
  public override void Configure(EntityTypeBuilder<PhoneDetail> builder)
  {
    builder.ToTable("PhoneDetails");

    builder.HasOne(e => e.Phone)
      .WithOne(e => e.Detail)
      .HasForeignKey<PhoneDetail>(d => d.PhoneId);

    base.Configure(builder);
  }
}
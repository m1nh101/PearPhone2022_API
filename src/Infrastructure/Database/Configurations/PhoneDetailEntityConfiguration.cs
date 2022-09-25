using Core.Entities.Stocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class PhoneDetailEntityConfiguration : BaseEntityConfiguration<PhoneDetail>
{
  public override void Configure(EntityTypeBuilder<PhoneDetail> builder)
  {
    builder.ToTable("PhoneDetails");

    base.Configure(builder);
  }
}
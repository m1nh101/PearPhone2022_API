using Core.Entities.Stocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Bases;

namespace Infrastructure.Database.Configurations;

public class ImageEntityConfiguration : BaseEntityConfiguration<Image>
{
  public override void Configure(EntityTypeBuilder<Image> builder)
  {
    builder.ToTable("Images");

    builder.Property(e => e.Url)
      .IsRequired();

    builder.HasOne(e => e.Phone)
      .WithMany(e => e.Images)
      .HasForeignKey(e => e.PhoneId);

    base.Configure(builder);
  }
}
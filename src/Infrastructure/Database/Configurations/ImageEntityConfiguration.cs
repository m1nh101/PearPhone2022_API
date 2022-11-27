using Core.Entities.Phones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class ImageEntityConfiguration : BaseEntityConfiguration<Image>
{
  public override void Configure(EntityTypeBuilder<Image> builder)
  {
    builder.ToTable("Images");

    builder.Property(e => e.Url)
      .IsRequired();

    builder.Property(e => e.ColorId)
      .IsRequired(false);

    builder.HasOne(e => e.Phone)
      .WithMany(e => e.Images)
      .HasForeignKey(e => e.PhoneId);

    builder.HasOne(e => e.Color)
      .WithMany(e => e.Images)
      .HasForeignKey(e => e.ColorId);

    base.Configure(builder);
  }
}
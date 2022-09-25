using Core.Entities.Stocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class ColorEntityConfiguration : BaseEntityConfiguration<Color>
{
  public override void Configure(EntityTypeBuilder<Color> builder)
  {
    builder.ToTable("Colors");

    builder.Property(e => e.Name)
      .HasMaxLength(500)
      .HasColumnType("varchar")
      .IsRequired();

    builder.Property(e => e.RGB)
      .HasMaxLength(50)
      .HasColumnType("varchar")
      .IsRequired();

    base.Configure(builder);
  }
}
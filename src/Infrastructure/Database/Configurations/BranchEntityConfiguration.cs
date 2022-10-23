using Core.Entities.Phones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class BranchEntityConfiguration : BaseEntityConfiguration<Branch>
{
  public override void Configure(EntityTypeBuilder<Branch> builder)
  {
    builder.ToTable("Branches");

    builder.Property(e => e.Name)
      .HasMaxLength(500)
      .HasColumnType("varchar")
      .IsRequired();

    base.Configure(builder);
  }
}
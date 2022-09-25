using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Bases;

namespace Infrastructure.Database.Configurations;

public abstract class BaseModifierConfiguration<TEntity> : BaseEntityConfiguration<TEntity>
  where TEntity : ModifierEntity
{
  public override void Configure(EntityTypeBuilder<TEntity> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(e => e.Id).ValueGeneratedOnAdd();

    builder.Property(e => e.CreatedBy)
      .HasMaxLength(100)
      .HasColumnType("varchar")
      .IsRequired();

    builder.Property(e => e.UpdatedBy)
      .HasMaxLength(100)
      .HasColumnType("varchar")
      .IsRequired();

    base.Configure(builder);
  }
}
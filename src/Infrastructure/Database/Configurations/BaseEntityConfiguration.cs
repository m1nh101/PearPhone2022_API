using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Bases;

namespace Infrastructure.Database.Configurations;

public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
  where TEntity : Entity
{
  public virtual void Configure(EntityTypeBuilder<TEntity> builder)
  {
    builder.HasKey(e => e.Id);
    builder.Property(e => e.Id).ValueGeneratedOnAdd();
  }
}
namespace Terminator.Infrastructure.Data.EntityConfigurations
{
  using Terminator.Core.Models.Base;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;

  /// <summary>
  /// Base class for the EF Core configuration
  /// </summary>
  /// <typeparam name="T">Type of the entity</typeparam>
  public abstract class EntityTypeConfigurationBase<T> : IEntityTypeConfiguration<T>
    where T : EntityBase
  {
    /// <summary>
    /// The database schema
    /// </summary>
    protected const string SCHEMA = "dbo";

    /// <inheritdoc />
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
      builder.Property(e => e.CreatedAt)
        .ValueGeneratedOnAdd()
        .HasDefaultValueSql("GetUtcDate()");

      builder.Property(e => e.UpdatedAt)
        .ValueGeneratedOnAddOrUpdate()
        .HasDefaultValueSql("GetUtcDate()");
    }
  }
}

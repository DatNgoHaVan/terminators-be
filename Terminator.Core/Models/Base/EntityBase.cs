namespace Terminator.Core.Models.Base
{
  using System;
  using Terminator.Core.Models.Interfaces;

  /// <summary>
  /// Represents the base class of the entity
  /// </summary>
  public abstract class EntityBase : IEntity
  {
    /// <summary>
    /// Timestamp when the record is created
    /// </summary>
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;

    /// <summary>
    /// Timestamp when the record is last updated
    /// </summary>
    public DateTime UpdatedAt { get; protected set; } = DateTime.UtcNow;
  }
}

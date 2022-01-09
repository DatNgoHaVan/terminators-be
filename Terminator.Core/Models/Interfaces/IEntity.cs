namespace Terminator.Core.Models.Interfaces
{
  using System;

  /// <summary>
  /// Represents an Entity Framework entity model
  /// </summary>
  public interface IEntity
  {
    /// <summary>
    /// Timestamp when the record is created
    /// </summary>
    DateTime CreatedAt { get; }

    /// <summary>
    /// Timestamp when the record is last updated
    /// </summary>
    DateTime UpdatedAt { get; }
  }
}

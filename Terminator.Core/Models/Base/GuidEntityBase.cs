namespace Terminator.Core.Models.Base
{
  using System;

  /// <summary>
  /// Represents the base class of the entity where the primary key is GUID
  /// </summary>
  public abstract class GuidEntityBase : SurrogateKeyEntityBase<Guid>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="GuidEntityBase"/> class
    /// </summary>
    /// <returns>A new instance of the <see cref="GuidEntityBase"/> class</returns>
    protected GuidEntityBase()
      : base(Guid.NewGuid())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GuidEntityBase"/> class
    /// </summary>
    /// <param name="id">The GUID</param>
    /// <returns>A new instance of the <see cref="GuidEntityBase"/> class</returns>
    protected GuidEntityBase(Guid id)
      : base(id)
    {
    }
  }
}

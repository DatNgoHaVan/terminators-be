namespace Terminator.Core.Models.Base
{
  /// <summary>
  /// Represents the base class of an Entity Framework entity model
  /// where the primary key is created by the system and does not relate to
  /// the business logic
  /// </summary>
  public abstract class SurrogateKeyEntityBase<TId> : EntityBase where TId : struct
  {
    /// <summary>
    /// The unique ID
    /// </summary>
    public TId Id { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SurrogateKeyEntityBase{TId}"/> class
    /// </summary>
    /// <returns>A new instance of the <see cref="SurrogateKeyEntityBase{TId}"/> class</returns>
    protected SurrogateKeyEntityBase()
      : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SurrogateKeyEntityBase{TId}"/> class
    /// </summary>
    /// <param name="id">The ID</param>
    /// <returns>A new instance of the <see cref="SurrogateKeyEntityBase{TId}"/> class</returns>
    protected SurrogateKeyEntityBase(TId id)
      : base()
    {
      Id = id;
    }

    /// <summary>
    /// Determines whether the instance is new
    /// </summary>
    /// <returns>True if the instance is new. Otherwise false.</returns>
    public bool IsTransient()
    {
      return Id.Equals(default(TId));
    }

    /// <summary>
    /// Determines whether two objects are equal
    /// </summary>
    /// <returns>True if two objects are equal. Otherwise false.</returns>
    public override bool Equals(object? obj)
    {
      if (obj == null || !(obj is SurrogateKeyEntityBase<TId>))
      {
        return false;
      }

      if (ReferenceEquals(this, obj))
      {
        return true;
      }

      if (GetType() != obj.GetType())
      {
        return false;
      }

      var item = (SurrogateKeyEntityBase<TId>)obj;

      if (item.IsTransient() || IsTransient())
      {
        return false;
      }

      return item == this;
    }

    private int? _requestedHashCode;

    /// <summary>
    /// Gets the hash code
    /// </summary>
    public override int GetHashCode()
    {
      if (!IsTransient())
      {
        if (!_requestedHashCode.HasValue)
        {
          _requestedHashCode = Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
        }

        return _requestedHashCode.Value;
      }

      return base.GetHashCode();
    }
  }
}

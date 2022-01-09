namespace Terminator.Core.Models.Base
{
    /// <summary>
    /// Represents the base class of an Entity Framework entity model where the primary key is integer
    /// </summary>
    public abstract class NumericEntityBase : SurrogateKeyEntityBase<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumericEntityBase"/> class
        /// </summary>
        /// <returns>A new instance of the <see cref="NumericEntityBase"/> class</returns>
        protected NumericEntityBase()
          : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NumericEntityBase"/> class
        /// </summary>
        /// <param name="id">The integeral ID</param>
        /// <returns>A new instance of the <see cref="NumericEntityBase"/> class</returns>
        protected NumericEntityBase(int id)
          : base(id)
        {
        }
    }
}

namespace Terminator.Core.Models.Base
{
    /// <summary>
    /// Represents the base class of the entity where the table is key-value
    /// </summary>
    public abstract class KeyValueEntityBase : NumericEntityBase
    {
        /// <summary>
        /// The entity key
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// The entity value
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyValueEntityBase"/> class
        /// </summary>
        /// <returns>A new instance of the <see cref="KeyValueEntityBase"/> class</returns>
        protected KeyValueEntityBase(string key, string value)
          : base()
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyValueEntityBase"/> class
        /// </summary>
        /// <param name="id">The integeral ID</param>
        /// <param name="key">The key</param>
        /// <param name="value">The value</param>
        /// <returns>A new instance of the <see cref="KeyValueEntityBase"/> class</returns>
        protected KeyValueEntityBase(int id, string key, string value)
          : base(id)
        {
            Key = key;
            Value = value;
        }
    }
}

namespace Terminator.Core.Models.Repositories
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets all entities
        /// </summary>
        IQueryable<TEntity> GetAll(CancellationToken token = default);

        /// <summary>
        /// Adds an entity
        /// </summary>
        Task<TEntity> AddAsync(TEntity entity, CancellationToken token = default);

        /// <summary>
        /// Updates an entity
        /// </summary>
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken token = default);

        /// <summary>
        /// Removes an entity
        /// </summary>
        Task<TEntity> RemoveAsync(TEntity entity, CancellationToken token = default);
    }
}

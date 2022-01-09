namespace Terminator.Infrastructure.Data.Repositories
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Terminator.Core.Models.Repositories;

    /// <inheritdoc />
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The database context
        /// </summary>
        protected AppDbContext DataContext { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class
        /// </summary>
        /// <param name="dataContext">The database context</param>
        public Repository(AppDbContext dataContext)
        {
            DataContext = dataContext;
        }

        /// <inheritdoc/>
        public IQueryable<TEntity> GetAll(CancellationToken token = default)
        {
            return DataContext.Set<TEntity>();
        }

        /// <inheritdoc/>
        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken token)
        {
            await DataContext.AddAsync(entity, token).ConfigureAwait(false);
            await DataContext.SaveChangesAsync(token).ConfigureAwait(false);

            return entity;
        }

        /// <inheritdoc/>
        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken token)
        {
            DataContext.Update(entity);
            await DataContext.SaveChangesAsync(token).ConfigureAwait(false);

            return entity;
        }

        /// <inheritdoc/>
        public async Task<TEntity> RemoveAsync(TEntity entity, CancellationToken token)
        {
            DataContext.Remove(entity);

            await DataContext.SaveChangesAsync(token).ConfigureAwait(false);

            return entity;
        }
    }
}

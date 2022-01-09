namespace Terminator.Core.Repositories
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Terminator.Core.Models;
    using Terminator.Core.Models.Repositories;

    /// <summary>
    /// Provides the method to work with the employee entity
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Gets all employees
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The collection of users</returns>
        Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the user by ID
        /// </summary>
        /// <param name="id">The user ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The user if found; otherwise, null</returns>
        Task<User?> GetUserById(int id, CancellationToken cancellationToken = default);

        Task<User> AddUser(User user, CancellationToken cancellationToken = default);
        Task<UserLogin?> LoginAsync(string email, string password, CancellationToken cancellationToken);
    }
}

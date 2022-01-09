namespace Terminator.Infrastructure.Data.Repositories
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Terminator.Core.Models;
    using Terminator.Core.Repositories;
    using System.Linq;

    /// <inheritdoc />
    public class UserRepository : Repository<User>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class
        /// </summary>
        /// <param name="dataContext">The database context</param>
        public UserRepository(AppDbContext dataContext)
          : base(dataContext)
        {
        }

        public Task<User> AddAsync(User entity, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task<User> AddUser(User user, CancellationToken cancellationToken = default)
        {
            await DataContext.Users.AddAsync(user, cancellationToken).ConfigureAwait(false);
            await DataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return user;
        }

        public IQueryable<User> GetAll(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserById(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<UserLogin?> LoginAsync(string email, string password, CancellationToken cancellationToken)
        {
            var user = await DataContext.Users
                            .FirstOrDefaultAsync(m => m.Email == email && m.PasswordHash == password, cancellationToken).ConfigureAwait(false);
            if(user != null)
            {
                return new UserLogin (email, password);
            }

            return null;
        }

        public Task<User> RemoveAsync(User entity, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User entity, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}

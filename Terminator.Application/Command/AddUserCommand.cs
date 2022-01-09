namespace Terminator.Application.Commands
{
    using MediatR;
    using Universely.AspNetCore.MediatR;
    using Terminator.Core.Models;
    using Universely.Types;

    /// <summary>
    /// Command to add an employee
    /// </summary>
    public class AddUserCommand : IRequest<Result<User>>, IFluentValidatable
    {

        /// <summary>
        /// The user email address
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// The user mobile number
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddUserCommand"/> class
        /// </summary>
        public AddUserCommand(string firstName, string lastName, string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}

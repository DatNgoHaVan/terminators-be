namespace Terminator.Api.Payload
{
    using System;

    /// <summary>
    /// The response of create user action
    /// </summary>
    public class CreateUserResponse
    {
        /// <summary>
        /// Gets the user ID
        /// </summary>
        /// <value>Returns the user ID</value>
        public int UserId { get; set; }

        /// <summary>
        /// Gets the created user
        /// </summary>
        /// <value>Returns the created user</value>
        public UserDto User { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserResponse"/> class
        /// </summary>
        /// <param name="userId">The employee ID</param>
        /// <param name="user">The created employee</param>
        public CreateUserResponse(int employeeId, UserDto user)
        {
            UserId = employeeId;
            User = user;
        }
    }
}

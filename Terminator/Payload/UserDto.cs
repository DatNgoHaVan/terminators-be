using System.Collections.Generic;

namespace Terminator.Api.Payload
{
    /// <summary>
    /// The DTO of the list user action
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// The user first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The user last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The user email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The user mobile number
        /// </summary>
        public string Mobile { get; set; }
    }
}

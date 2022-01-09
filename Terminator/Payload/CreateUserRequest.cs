namespace Terminator.Api.Payload
{
    /// <summary>
    /// The request to create employee
    /// </summary>
    public class CreateUserRequest
    {
        //public int DepartmentId { get; set; }

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

        //public AddressRequest Address { get; set; }
    }

    //public class AddressRequest
    //{
    //    public string HouseNumber { get; set; }
    //    public string Street { get; set; }
    //    public string Ward { get; set; }
    //    public string District { get; set; }
    //    public string City { get; set; }
    //    public string Province { get; set; }
    //}
}

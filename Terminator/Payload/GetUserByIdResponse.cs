namespace Terminator.Api.Payload
{
    /// <summary>
    /// The response to get an employee by ID
    /// </summary>
    public class GetUserByIdResponse
    {
        /// <summary>
        /// The employee ID
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// The user
        /// </summary>
        public UserDto Employee { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserByIdResponse"/> class
        /// </summary>
        /// <param name="employeeId">The employee ID</param>
        /// <param name="employee">the employee DTO</param>
        public GetUserByIdResponse(int employeeId, UserDto employee)
        {
            EmployeeId = employeeId;
            Employee = employee;
        }
    }
}

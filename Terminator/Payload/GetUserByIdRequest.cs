namespace Terminator.Api.Payload
{
  using System;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.AspNetCore.Mvc.ModelBinding;

  /// <summary>
  /// The request to get an employee by ID
  /// </summary>
  public class GetUserByIdRequest
    {
    /// <summary>
    /// The employee ID
    /// </summary>
    [BindRequired, FromRoute(Name = "id")]
    public int EmployeeId { get; set; }
  }
}

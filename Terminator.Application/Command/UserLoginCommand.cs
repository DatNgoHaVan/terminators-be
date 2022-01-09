using MediatR;
using Terminator.Core.Models;
using Universely.AspNetCore.MediatR;
using Universely.Types;

namespace Terminator.Application.Command
{
    public class UserLoginCommand : IRequest<Result<UserLogin>>, IFluentValidatable
    {
        public string Email { get; init; } = String.Empty;

        public string Password { get; init; } = String.Empty;
    }
}

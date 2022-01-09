namespace Terminator.Application.Commands
{
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using MediatR;
    using Terminator.Core.Models;
    using Terminator.Core.Repositories;
    using Universely.Types;
    using Terminator.Application.Command;

    /// <summary>
    /// Handles the <see cref="UserLoginCommandHandler"/>
    /// </summary>
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, Result<UserLogin>>
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddUserCommandHandler"/> class
        /// </summary>
        public UserLoginCommandHandler(IUserRepository employeeRepository, IMapper mapper)
        {
            _userRepository = employeeRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<Result<UserLogin>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _userRepository.LoginAsync(request.Email, request.Password, cancellationToken).ConfigureAwait(false);
            }
            catch (DataException ex)
            {
                return new Failure(ex.Message, ex);
            }
        }
    }
}

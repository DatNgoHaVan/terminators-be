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
    using Microsoft.Extensions.Logging;
    using Terminator.Core.Constants;

    /// <summary>
    /// Handles the <see cref="AddUserCommandHandler"/>
    /// </summary>
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Result<User>>
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddUserCommandHandler"/> class
        /// </summary>
        public AddUserCommandHandler(ILogger<AddUserCommandHandler> logger, IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _userRepository = userRepository;
        }

        /// <inheritdoc />
        public async Task<Result<User>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _mapper.Map<User>(request);
                //TODO NhatNguyen handle password hash
                user.PasswordHash = ApplicationConstant.DefaultPassword;
                return await _userRepository.AddUser(_mapper.Map<User>(request), cancellationToken).ConfigureAwait(false);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogInformation("Error occurred while mapping AddUserCommand to User", ex.Message);
                return new Failure(ex.Message, ex);
            }
            catch (DataException ex)
            {
                _logger.LogInformation(ex.Message, ex);
                return new Failure(ex.Message, ex);
            }
        }
    }
}

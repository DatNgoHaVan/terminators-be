namespace Terminator.API.Controllers
{
    using AutoMapper;
    using Terminator.Application.Command;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Net.Mime;
    using Terminator.API.Payload;
    using Terminator.Core.Models;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Universely.AspNetCore.Constants;
    using Universely.AspNetCore.Mvc;
    using Versions = Api.Versions;

    [ApiVersion(Versions.ApiVersion.v1_0)]
    [Route("api/v1/users")]
    [Produces(MediaTypeNames.Application.Json)]
    public class UserController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountantController"/> class
        /// </summary>
        public UserController(ILogger<UserController> logger, IMediator mediator, IMapper mapper, IConfiguration configuration)
          : base(logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost("login")]
        [Produces(MediaTypeNames.Application.Json)]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request, CancellationToken cancellationToken = default)
        {
            var command = _mapper.Map<UserLoginCommand>(request);
            var response = await _mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return response.Match(
              s => {
                  return HandleLogin(s);
              },
              f =>
              {
                  return f.Message switch
                  {
                      ErrorMessage.ValidationErrorMessage => BadRequestResponse(f),
                      _ => NotOkResponse(f)
                  };
              }
            );
        }

        private IActionResult HandleLogin(UserLogin userLogin)
        {
            if (userLogin == null)
            {
                return NotFoundResponse();
            }

            var authClaims = new List<Claim> {
                            new Claim(ClaimTypes.Name, userLogin.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        };

            //foreach (var role in userLogin.Roles)
            //{
            //    authClaims.Add(new Claim(ClaimTypes.Role, role));
            //}

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
              );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }
    }
}

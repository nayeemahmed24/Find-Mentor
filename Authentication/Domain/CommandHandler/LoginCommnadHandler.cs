using Domain.Command;
using Domain.Utils.Interfaces;
using MediatR;
using Model.Dto;
using Model.Entities;
using Model.Response;
using Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommandHandler
{
    public class LoginCommnadHandler : IRequestHandler<LoginCommand, CommandResponse>
    {
        private readonly IPasswordHandler _passwordHandler;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUserService _userService;
        public LoginCommnadHandler(IPasswordHandler passwordHandler, ITokenHandler tokenHandler, IUserService userService) { 
            this._passwordHandler = passwordHandler;
            this._tokenHandler = tokenHandler;
            this._userService = userService;
        }

        public async Task<CommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = await _userService.GetAsync(request.CorrelationId, p => p.Email == request.Email, cancellationToken);
                if (user == null)
                {
                    return new CommandResponse(null, HttpStatusCode.BadRequest, "Please enter valid email and password.");
                }

                string hasedExistingPassword = user.Password;
                string hashedCurrentPassword = _passwordHandler.HashPassword(request.Password);

                if(hashedCurrentPassword != hashedCurrentPassword) {
                    return new CommandResponse(null, HttpStatusCode.BadRequest, "Please enter valid email and password.");
                }

                TokenDto accessToken = this._tokenHandler
                    .GenerateAccessToken(user);

                return new CommandResponse(accessToken, HttpStatusCode.OK, null);
            }
            catch (Exception ex)
            {
                return new CommandResponse(null, HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

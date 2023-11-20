using AutoMapper;
using Domain.Command;
using Domain.Utils.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Model.Dto;
using Model.Entities;
using Model.Response;
using Repository;
using Service.Abstraction;
using System.Net;

namespace Domain.CommandHandler
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, CommandResponse>
    {
        private readonly IValidator<RegisterCommand> _validator;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IPasswordHandler _passwordHandler;
        private readonly ITokenHandler _tokenHandler;
        public RegisterCommandHandler(IValidator<RegisterCommand> validator, IUserService userService, IMapper mapper, IPasswordHandler passwordHandler, ITokenHandler tokenHandler) 
        {
            this._validator = validator;
            this._userService = userService;
            this._mapper = mapper;
            this._passwordHandler = passwordHandler;
            this._tokenHandler = tokenHandler;
        }

        public async Task<CommandResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validation = await _validator.ValidateAsync(request);
                if (!validation.IsValid)
                {
                    return new CommandResponse(validation.Errors, HttpStatusCode.BadRequest, null);
                }

                User user = await _userService.GetAsync(request.CorrelationId, p => p.Email == request.Email, cancellationToken);

                if (user != null)
                {
                    return new CommandResponse(null, HttpStatusCode.BadRequest, "Email Already Exist");
                }

                UserDto userDto = _mapper.Map<RegisterCommand, UserDto>(request);
                userDto.Password = _passwordHandler.HashPassword(userDto.Password);

                UserDto userDtoRes = await _userService.CreateUser(request.CorrelationId, userDto, cancellationToken);

                return new CommandResponse(userDtoRes, HttpStatusCode.OK, null);
            }
            catch (Exception ex)
            {
                return new CommandResponse(null, HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }
    }
}

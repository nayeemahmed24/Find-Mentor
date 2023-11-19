using Domain.Command;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Model.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommandHandler
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, CommandResponse>
    {
        private readonly IValidator<RegisterCommand> _validator;
        public RegisterCommandHandler(IValidator<RegisterCommand> validator) 
        {
            this._validator = validator;
        }

        public async Task<CommandResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var validation = await _validator.ValidateAsync(request);
            if (!validation.IsValid) 
            {
                return new CommandResponse(validation.Errors, false, null);
            }
            return new CommandResponse(null, true, null);
        }
    }
}

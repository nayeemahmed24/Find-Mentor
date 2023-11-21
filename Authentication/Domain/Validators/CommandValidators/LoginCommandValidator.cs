using Domain.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators.CommandValidators
{
    public class LoginCommandValidator: AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator() {
            RuleFor(p => p.Email).NotEmpty().WithMessage("Please Enter Email Address")
                .EmailAddress().WithMessage("A valid email is required");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}

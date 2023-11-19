using Domain.Command;
using FluentValidation;

namespace Domain.Validators.CommandValidators
{
    public class RegisterCommandValidator: AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator() 
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email address is required")
                     .EmailAddress().WithMessage("A valid email is required");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Password is required");

        }
    }
}

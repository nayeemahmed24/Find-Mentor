using Domain.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators.CommandValidator
{
    public class AddMentorCommandValidator: AbstractValidator<AddMentorCommand>
    {
        public AddMentorCommandValidator() 
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name can not be empty");
            RuleFor(p => p.ProfileDescription).NotEmpty().WithMessage("Description can not be empty");
            RuleFor(p => p.UniversityId).NotEmpty().WithMessage("UniversityId can not be empty");
        }
    }
}

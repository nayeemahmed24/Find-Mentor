using Domain.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators.CommandValidator
{
    public class AddUniversityCommandValidator: AbstractValidator<AddUniversityCommand>
    {
        public AddUniversityCommandValidator() 
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("University Name can not be empty");
            RuleFor(p => p.City).NotEmpty().WithMessage("City Name can not be empty");
            RuleFor(p => p.Country).NotEmpty().WithMessage("Country Name can not be empty");
        }
    }
}

using Domain.Command;
using FluentValidation;

namespace Domain.Validators.CommandValidator
{
    public class AddReviewCommandValidator: AbstractValidator<AddReviewCommand>
    {
        public AddReviewCommandValidator()
        {
            RuleFor(p => p.MentorId).NotEmpty().WithMessage("MentorId can not be empty");
            RuleFor(p => p.Rating).NotEmpty().WithMessage("Rating can not be empty");

        }
    }
}

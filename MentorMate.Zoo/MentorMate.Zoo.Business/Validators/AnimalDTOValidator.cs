using FluentValidation;
using MentorMate.Zoo.Data.Constants;
using MentorMate.Zoo.Business.DTOs.AnimalDTOs;

namespace MentorMate.Zoo.Business.Validators
{
    public class AnimalDTOValidator : AbstractValidator<AnimalValidateDTO>
    {
        public AnimalDTOValidator()
        {
            RuleFor(a => a.Id)
                .GreaterThan(default(int))
                .When(a => a.ExistsInDatabase);

            RuleFor(a => a.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(DatabaseConfiguration.AnimalNameMaxLength);

            RuleFor(a => a.Species)
                .MaximumLength(DatabaseConfiguration.AnimalSpeciesMaxLength)
                .When(a => !a.ExistsInDatabase);

            RuleFor(a => a.Type)
                .NotNull()
                .IsInEnum()
                .When(a => !a.ExistsInDatabase);

            RuleFor(a => a.Class)
                .NotNull()
                .IsInEnum()
                .When(a => !a.ExistsInDatabase);

            RuleFor(a => a.Weight)
                .NotNull()
                .GreaterThan(default(decimal));

        }
    }
}

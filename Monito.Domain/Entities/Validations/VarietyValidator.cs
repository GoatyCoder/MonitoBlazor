using FluentValidation;
using FluentValidation.Results;

namespace Monito.Domain.Entities.Validations
{
    public class VarietyValidator : AbstractValidator<Variety>
    {
        public VarietyValidator()
        {
            RuleFor(p => p.Code).NotEmpty();
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}

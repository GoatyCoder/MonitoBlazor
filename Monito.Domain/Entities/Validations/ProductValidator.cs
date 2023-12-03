using FluentValidation;
using FluentValidation.Results;

namespace Monito.Domain.Entities.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Code).NotEmpty();
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}

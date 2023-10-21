using FluentValidation;
using schoolapp.Domain.Entities;

namespace schoolapp.Application.Common.Validation;
public class CategoryValidator : AbstractValidator<CartItem>
{
    public CategoryValidator()
    {
        RuleFor(p => p.ProductName)
            .MaximumLength(200)
            .NotEmpty();
    }
}

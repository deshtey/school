using FluentValidation;
using schoolapp.Domain.Entities;

namespace schoolapp.Application.Common.Validation;

public class ProductValidator : AbstractValidator<School>
{
    public ProductValidator()
    {
        RuleFor(p=>p.SchoolName)
            .MaximumLength(200)
            .NotEmpty();
    }
}

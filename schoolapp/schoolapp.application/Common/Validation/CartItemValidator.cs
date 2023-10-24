using FluentValidation;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Application.Common.Validation;
public class CategoryValidator : AbstractValidator<Student>
{
    public CategoryValidator()
    {
        RuleFor(p => p.Name)
            .MaximumLength(200)
            .NotEmpty();
    }
}

using FluentValidation;
using schoolapp.Domain.Entities;
using schoolapp.Models;

namespace schoolapp.Application.Common.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p=>p.ProductName)
            .MaximumLength(200)
            .NotEmpty();
    }
}

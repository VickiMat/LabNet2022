using FluentValidation;
using Practica.EF.Entities;

namespace Common.ValidationAPI
{
    public class ValidationCategories : AbstractValidator<Categories>
    {
        public ValidationCategories()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("The category name cannot be empty.");
            RuleFor(c => c.CategoryName).MaximumLength(15).WithMessage("The category name can have 15 lenght at max.");
        }

    }
}

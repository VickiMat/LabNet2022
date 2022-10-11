using FluentValidation;
using Practica.EF.Entities;

namespace Common.ValidationAPI
{
    public class ValidationSuppliers : AbstractValidator<Suppliers>
    {
        public ValidationSuppliers()
        {
            RuleFor(s => s.CompanyName).NotEmpty().WithMessage("Company name cannot be empty.");
            RuleFor(c => c.CompanyName).Length(5, 40).WithMessage("Category name can have 5 lenght at min and 40 lenght at max.");

            RuleFor(c => c.ContactName).MaximumLength(30).WithMessage("Contact name can´t have more than 30 lenght");

            RuleFor(s => s.City).NotEmpty().WithMessage("City cannot be empty.");
            RuleFor(s => s.City).MaximumLength(15).WithMessage("City can´t have more than 15 lenght");

            RuleFor(s => s.Country).MaximumLength(15).WithMessage("Country can´t have more than 15 lenght");
        }
    }
}

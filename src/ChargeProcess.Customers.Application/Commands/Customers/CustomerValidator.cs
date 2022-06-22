using FluentValidation;

namespace ChargeProcess.Customers.Application.Commands.Customers
{
    public class CustomerValidator : AbstractValidator<CustomerRequest>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Name)
                .NotEmpty()
                .WithMessage("The field cannot be null or empty.");

            RuleFor(customer => customer.DocumentId)
                .NotEmpty()
                .WithMessage("The field Cannot be null or empty.");

            RuleFor(customer => customer.DocumentId)
                .IsValidCPF()
                .WithMessage("The field must contain a valid document.");

            RuleFor(customer => customer.Province)
                .NotEmpty()
                .WithMessage("The field Cannot be null or empty.");
        }
    }
}

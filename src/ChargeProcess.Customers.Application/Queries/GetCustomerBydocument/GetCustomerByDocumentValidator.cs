using FluentValidation;

namespace ChargeProcess.Customers.Application.Queries.GetCustomerBydocument
{
    public class GetCustomerByDocumentValidator : AbstractValidator<string>
    {
        public GetCustomerByDocumentValidator()
        {
            RuleFor(customerId => customerId)
                .IsValidCPF()
                .WithMessage("The field must contain a valid document.")
                .NotEmpty()
                .WithMessage("the filed can not be empty");
        }
    }
}

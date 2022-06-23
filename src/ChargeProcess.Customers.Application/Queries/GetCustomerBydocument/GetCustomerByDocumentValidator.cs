using FluentValidation;

namespace ChargeProcess.Customers.Application.Queries.GetCustomerBydocument
{
    public class GetCustomerByDocumentValidator : AbstractValidator<GetCustomerByDocumentRequest>
    {
        public GetCustomerByDocumentValidator()
        {
            RuleFor(customer => customer.DocumentId)
                .IsValidCPF()
                .WithMessage("The field must contain a valid document.")
                .NotEmpty()
                .WithMessage("the filed can not be empty");
        }
    }
}

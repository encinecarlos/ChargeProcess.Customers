using ChargeProcess.Customers.Domain.Common;

namespace ChargeProcess.Customers.Application.Services
{
    public interface IMessageService<T> where T : MessageBase
    {
        Task<T> ReturnError(T response, string message, int statusCode, CancellationToken cancellationToken);
    }
}
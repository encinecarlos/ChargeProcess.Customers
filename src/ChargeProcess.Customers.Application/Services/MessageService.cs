using ChargeProcess.Customers.Domain.Common;

namespace ChargeProcess.Customers.Application.Services
{
    public class MessageService<T> : IMessageService<T> where T : MessageBase
    {
        public async Task<T> ReturnError(T response, string message, int statusCode, CancellationToken cancellationToken)
        {
            response.Message = message;
            response.StatusCode = statusCode;

            return await Task.FromResult(response);
        }
    }
}

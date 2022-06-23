namespace ChargeProcess.Customers.Domain.Common
{
    public abstract class MessageBase
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}

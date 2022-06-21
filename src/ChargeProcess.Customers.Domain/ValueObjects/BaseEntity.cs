using System.Text.Json.Serialization;

namespace ChargeProcess.Customers.Domain.ValueObjects
{
    public class BaseEntity
    {
        [JsonPropertyName("/id")]
        public string Id { get; set; }
    }
}

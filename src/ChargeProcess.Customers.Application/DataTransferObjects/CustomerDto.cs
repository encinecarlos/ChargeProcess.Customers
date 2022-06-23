using System.Text.Json.Serialization;

namespace ChargeProcess.Customers.Application.DataTransferObjects
{
    public class CustomerDto
    {
        public string Id { get; set; }
        
        [JsonPropertyName("Nome")]
        public string Name { get; set; }

        [JsonPropertyName("CPF")]
        public long Document { get; set; }
        
        [JsonPropertyName("UF")]
        public string Province { get; set; }
    }
}

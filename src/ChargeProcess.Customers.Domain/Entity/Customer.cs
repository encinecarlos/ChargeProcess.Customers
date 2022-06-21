﻿using ChargeProcess.Customers.Domain.ValueObjects;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ChargeProcess.Customers.Domain.Entity
{
    public class Customer 
    {
        //[JsonPropertyName("id")]
        public string Id { get; set; }
        public string? Name { get; set; }

        public string? Province { get; set; }

        public string? DocumentId { get; set; }
    }
}

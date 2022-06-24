namespace ChargeProcess.Customers.Domain.Entity
{
    public class Customer 
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Province { get; set; }

        public long DocumentId { get; set; }
        public bool LeadByZero { get; set; }
    }
}

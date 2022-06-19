using Google.Cloud.Firestore;

namespace ChargeProcess.Customers.Domain.Entity
{
    [FirestoreData]
    public class Customer
    {
        [FirestoreProperty]
        public string? Name { get; set; }

        [FirestoreProperty]
        public string? Province { get; set; }

        [FirestoreProperty]
        public string? DocumentId { get; set; }
    }
}

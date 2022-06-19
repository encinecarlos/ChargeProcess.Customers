using ChargeProcess.Customers.Application.Extensions;
using ChargeProcess.Customers.Domain.ValueObjects;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeProcess.Customers.Application.Commands.Customers
{
    internal class CustomerCommand : IRequestHandler<CustomerRequest, CustomerResponse>
    {
        //private IGetFirestoreCredentials Credentials { get; set; }

        private IOptionsMonitor<KeySettings> Options { get; set; }

        public CustomerCommand(IOptionsMonitor<KeySettings> options)
        {
            Options = options;
        }

        public async Task<CustomerResponse> Handle(CustomerRequest request, CancellationToken cancellationToken)
        {
            var credential = GoogleCredential.GetApplicationDefault();
            var db = new FirestoreDbBuilder()
            {
                Credential = credential,
                ProjectId = "chargeprocess-353805"
            }.Build();

            CollectionReference collection = db.Collection("Customers");

            await collection.AddAsync(request.Customer);

            var secret = Options.CurrentValue;

            return await Task.FromResult(new CustomerResponse() { MySecret = secret.Service});
        }
    }
}

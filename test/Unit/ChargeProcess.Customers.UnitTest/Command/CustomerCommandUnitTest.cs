using Bogus;
using ChargeProcess.Customers.Application.Commands.Customers;
using ChargeProcess.Customers.Application.Queries.GetCustomerBydocument;
using ChargeProcess.Customers.Application.Services;
using ChargeProcess.Customers.Domain.Entity;
using ChargeProcess.Customers.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ChargeProcess.Customers.UnitTest.Command
{
    
    public class CustomerCommandUnitTest
    {
        private Mock<ICustomerReadRepository> CustomerReadRepository { get; }
        private Mock<ICustomerWriteRepository> CustomerWriteRepository { get; }
        private Mock<IMessageService<CustomerResponse>> MessageService { get; }
        private Mock<IMessageService<GetCustomerByDocumentResponse>> GetCustomerMessageService { get; }

        public CustomerCommandUnitTest()
        {
            CustomerWriteRepository = new Mock<ICustomerWriteRepository>();
            CustomerReadRepository = new Mock<ICustomerReadRepository>();
            MessageService = new Mock<IMessageService<CustomerResponse>>();
        }

        [Fact(DisplayName = "Should save new customer")]
        public async Task ShouldSaveNewCustomer()
        {
            var faker = new Faker("pt_BR");
            CustomerReadRepository.Setup(c => c.GetCustomerByDocument(It.IsAny<string>()))
                .Returns(Task.FromResult(new Customer()));

            var request = new CustomerRequest
            {
                DocumentId = "12312312365",
                Name = faker.Name.FullName(),
                Province = faker.Address.StateAbbr()
            };

            var comamnd = new CustomerCommand(CustomerWriteRepository.Object, CustomerReadRepository.Object, MessageService.Object);
            var handler = await comamnd.Handle(request, new CancellationToken());

            Assert.Equal(StatusCodes.Status200OK, handler.StatusCode);
        }
        
        [Fact(DisplayName = "Should not save new customer")]
        public async Task ShouldNotSaveNewCustomer()
        {
            var faker = new Faker("pt_BR");
            CustomerReadRepository.Setup(c => c.GetCustomerByDocument(It.IsAny<string>()))
                .Returns(ReturnCustomer());

            var request = new CustomerRequest
            {
                DocumentId = "12312312365",
                Name = faker.Name.FullName(),
                Province = faker.Address.StateAbbr()
            };

            var comamnd = new CustomerCommand(CustomerWriteRepository.Object, CustomerReadRepository.Object, MessageService.Object);
            var handler = await comamnd.Handle(request, new CancellationToken());

            Assert.Equal(StatusCodes.Status500InternalServerError, handler.StatusCode);
        }

        private static Task<Customer> ReturnCustomer()
        {
            return Task.FromResult(new Customer() 
            { 
                Id = Guid.NewGuid().ToString(), 
                DocumentId = 12312312365, 
                LeadByZero = false, 
                Name = "Random Name", 
                Province = "MT" 
            });
        }
    }
}

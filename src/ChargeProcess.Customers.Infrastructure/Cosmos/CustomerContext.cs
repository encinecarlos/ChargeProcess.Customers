using ChargeProcess.Customers.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeProcess.Customers.Infrastructure.Cosmos
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToContainer("Customers");
            //modelBuilder.Entity<Customer>().HasNoKey();
            modelBuilder.Entity<Customer>().HasPartitionKey(p => p.Id);
        }
    }
}

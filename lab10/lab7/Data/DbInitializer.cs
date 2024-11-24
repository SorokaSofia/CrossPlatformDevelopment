using System;
using System.Linq;
using Lab7.Models;

namespace Lab7.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            if (context.Customers.Any())
                return;

            var customers = new List<Customer>
            {
                new Customer
                {
                    FirstName = "John",
                    LastName = "Doe",
                    EmailAddress = "john.doe@example.com",
                    PhoneNumber = "123-456-7890"
                },
                new Customer
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    EmailAddress = "jane.smith@example.com",
                    PhoneNumber = "098-765-4321"
                }
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

    }
}

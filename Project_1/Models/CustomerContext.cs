using System.Collections.Generic;

namespace Project_1.Models
{
    public static class CustomerContext //can handle customer data
    {
        public static List<Customer> Customers = new()
        {
            new Customer { Id=1,FirstName = "Leon", LastName = "Brave" },
            new Customer { Id=2,FirstName = "Afool", LastName = "AsFallen" }
        };
    }
}
using System.Collections.Generic;

namespace Project_1.Models
{
    public static class CustomerContext //can handle customer data
    {
        public static List<Customer> Customers = new()
        {
            new Customer { FirstName = "Leon", LastName = "Brave" },
            new Customer { FirstName = "Afool", LastName = "AsFallen" }
        };
    }
}
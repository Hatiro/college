using System;
using System.Diagnostics.CodeAnalysis;

namespace Task3
{
    internal static class Program
    {
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        private static void Main()
        {
            var customers = Customer.Create(20);
            
            Console.WriteLine("ALL CUSTOMERS");
            Customer.WriteCustomers(customers);
            
            Console.WriteLine();
            Console.WriteLine("ALL CUSTOMERS SORTED BY NAME");
            Customer.WriteCustomers(Customer.OrderByName(customers));
            
            Console.WriteLine();
            Console.WriteLine("Minimum card number: ");
            if (!ulong.TryParse(Console.ReadLine(), out var minCardNumber))
                return;
            Console.WriteLine("Maximum card number: ");
            if (!ulong.TryParse(Console.ReadLine(), out var maxCardNumber))
                return;
            
            Console.WriteLine();
            Console.WriteLine("ALL CUSTOMERS WHOSE CARD NUMBERS ARE BETWEEN THE MIN AND MAX VALUES");
            Customer.WriteCustomers(Customer.CreditCardBetween(customers, minCardNumber, maxCardNumber));
        }
    }
}
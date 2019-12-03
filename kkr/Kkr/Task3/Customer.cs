using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Bogus.DataSets;

namespace Task3
{
    internal sealed class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ulong CreditCard { get; set; }

        public override string ToString()
        {
            return $"{Id}. {FirstName} {LastName}, {CreditCard}";
        }

        private static readonly Faker<Customer> Faker = new Faker<Customer>()
            .RuleFor(x => x.Id, f => f.IndexGlobal + 1)
            .RuleFor(x => x.CreditCard, f =>
                ulong.Parse(f.Finance.CreditCardNumber(CardType.Mastercard).Replace("-", string.Empty)))
            .RuleFor(x => x.FirstName, f => f.Person.FirstName)
            .RuleFor(x => x.LastName, f => f.Person.LastName);

        public static IEnumerable<Customer> Create(int count) => Faker.Generate(count);

        public static IEnumerable<Customer> OrderByName(IEnumerable<Customer> customers) =>
            customers.OrderBy(c => c.FirstName).ThenBy(c => c.LastName);

        public static IEnumerable<Customer> CreditCardBetween(IEnumerable<Customer> customers,
            ulong start, ulong end) =>
            customers.Where(c => c.CreditCard >= start && c.CreditCard <= end);

        public static void WriteCustomers(IEnumerable<Customer> customers) =>
            Console.WriteLine(string.Join(Environment.NewLine, customers));
    }
}
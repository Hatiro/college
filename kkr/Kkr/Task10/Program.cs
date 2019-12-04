using System;
using Bogus;

namespace Task10
{
    internal static class Program
    {
        private static void Main()
        {
            string[] regions = { "Region 1", "Region 2", "Region 3", "Region 4" };
            var faker = new Faker<Country>()
                .RuleFor(x => x.CapitalCity, f => f.Person.Address.City)
                .RuleFor(x => x.CentersOfRegions, f => f.Random.ArrayElements(regions))
                .RuleFor(x => x.CountOfRegions, (f, c) => c.CentersOfRegions.Length)
                .RuleFor(x => x.Square, f => f.Random.Decimal(10M, 400M));

            var countries = faker.Generate(20);

            Console.WriteLine(string.Join(Environment.NewLine + Environment.NewLine, countries));
        }
    }
}
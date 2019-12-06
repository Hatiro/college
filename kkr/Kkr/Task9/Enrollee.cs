using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;

namespace Task9
{
    internal sealed class Enrollee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public IEnumerable<int> Marks { get; set; }

        public override string ToString()
        {
            return "ENROLLEE" +
               Environment.NewLine +
               $"{Id}. {FirstName} {LastName}" +
                Environment.NewLine +
                $"Address: {Address}" +
                Environment.NewLine +
                $"Marks: {string.Join(", ", Marks)}";
        }
        
        private static readonly Faker<Enrollee> Faker = new Faker<Enrollee>()
            .RuleFor(x => x.Address, f => f.Address.FullAddress())
            .RuleFor(x => x.Id, f => f.IndexGlobal + 1)
            .RuleFor(x => x.FirstName, f => f.Person.FirstName)
            .RuleFor(x => x.LastName, f => f.Person.LastName)
            .RuleFor(x => x.Marks, f => f.Random.Digits(3, 1, 5));

        public static IEnumerable<Enrollee> CreateEnrollees(int count) =>
            Faker.Generate(count);
        
        public static void PrintEnrollees(IEnumerable<Enrollee> enrollees) =>
            Console.WriteLine(string.Join(Environment.NewLine + Environment.NewLine, enrollees));

        public static IEnumerable<Enrollee> WithBadMarks(IEnumerable<Enrollee> enrollees) =>
            enrollees.Where(e => e.Marks.Any(m => m <= 2));

        public static IEnumerable<Enrollee>
            WhoseAverageMarkGreaterThan(IEnumerable<Enrollee> enrollees, double pointer) =>
            enrollees.Where(e => e.Marks.Average() > pointer);
    }
}
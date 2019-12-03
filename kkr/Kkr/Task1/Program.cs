using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Bogus;

namespace Task1
{
    internal static class Program
    {
        [SuppressMessage("ReSharper", "InvertIf")]
        private static void Main()
        {
            string[] groups = { "Group 1", "Group 2", "Group 3" };
            var faker = new Faker<Student>()
                .RuleFor(x => x.Id, f => f.IndexGlobal + 1)
                .RuleFor(x => x.FirstName, f => f.Person.FirstName)
                .RuleFor(x => x.LastName, f => f.Person.LastName)
                .RuleFor(x => x.YearOfBirth, f => f.Random.Int(1970, 2000))
                .RuleFor(x => x.GroupName, f => f.PickRandom(groups));
            
            var students = faker.Generate(30);
            
            students.ForEach(Console.WriteLine);
            
            Console.WriteLine();
            Console.Write($"Please, input the name of the group ({string.Join(", ", groups)}): ");
            var groupName = Console.ReadLine();
            foreach (var student in students.Where(s =>
                s.GroupName.Equals(groupName, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine(student);
            }
            
            Console.WriteLine();
            Console.Write("Please, input the year of birth: ");
            if (int.TryParse(Console.ReadLine(), out var yearOfBirth))
                foreach (var student in students.Where(s => s.YearOfBirth > yearOfBirth))
                    Console.WriteLine(student);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;

namespace Task6
{
    internal sealed class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string InsuranceNumber { get; set; }
        public string Diagnosis { get; set; }

        public override string ToString()
        {
            return $"{Id}. {FirstName} {LastName}, {Phone}" +
                Environment.NewLine +
                $"Address: {Address}" +
                Environment.NewLine +
                $"Insurance number: {InsuranceNumber}" +
                Environment.NewLine +
                $"Diagnosis: {Diagnosis}";
        }
        
        private static readonly Faker<Patient> Faker = new Faker<Patient>()
            .RuleFor(x => x.Address, f => f.Address.FullAddress())
            .RuleFor(x => x.Id, f => f.IndexGlobal + 1)
            .RuleFor(x => x.Diagnosis, f => f.PickRandom(Program.Diagnosis))
            .RuleFor(x => x.FirstName, f => f.Person.FirstName)
            .RuleFor(x => x.LastName, f => f.Person.LastName)
            .RuleFor(x => x.Phone, f => f.Person.Phone)
            .RuleFor(x => x.InsuranceNumber, f => f.Finance.Account());

        public static IEnumerable<Patient> CreatePatients(int count) =>
            Faker.Generate(20);

        public static IEnumerable<Patient> WithDiagnosis(IEnumerable<Patient> patients, string diagnosis) =>
            patients.Where(p => p.Diagnosis == diagnosis);
        
        public static void PrintPatients(IEnumerable<Patient> patients) =>
            Console.WriteLine(string.Join(Environment.NewLine, patients));
    }
}
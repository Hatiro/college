using System;
using Bogus;

namespace Task4
{
    internal static class Program
    {
        private static void Main()
        {
            var faker = new Faker<Car>()
                .RuleFor(x => x.Model, f => f.Vehicle.Model())
                .RuleFor(x => x.FuelType, f => f.Vehicle.Fuel())
                .RuleFor(x => x.VehicleType, f => f.Vehicle.Type())
                .RuleFor(x => x.Manufacturer, f => f.Vehicle.Manufacturer());

            var cars = faker.Generate(20);
            foreach (var car in cars)
            {
                Console.WriteLine(car);
                car.Drive();
                car.Fuel();
                car.Repair();
                car.PrintModel();
                Console.WriteLine();
            }
        }
    }
}
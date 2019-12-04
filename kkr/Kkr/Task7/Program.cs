using System;
using Bogus;

namespace Task7
{
    internal static class Program
    {
        private static readonly string[] Routes = { "Kyiv-Israel", "China-USA" };
        
        private static void Main()
        {
            var planes = new Faker<Plane>()
                .RuleFor(x => x.Route, f => f.PickRandom(Routes))
                .Generate(20);

            foreach (var plane in planes)
            {
                Console.WriteLine(plane);
                plane.Fly();
                Console.WriteLine();
            }
        }
    }
}
using System;

namespace Task2
{
    internal static class Program
    {
        private static void Main()
        {
            var text = new Text(5, 3)
            {
                Title = "Some custom title"
            };
            
            Console.WriteLine("FULL TEXT");
            Console.WriteLine(text);
            Console.WriteLine();
            
            Console.WriteLine("ADDING 2 PARAGRAPHS DYNAMICALLY");
            text.AddParagraphs(Text.Faker.Generate(2));
            Console.WriteLine(text);
        }
    }
}
using System;
using System.Diagnostics.CodeAnalysis;

namespace Task9
{
    internal static class Program
    {
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        private static void Main()
        {
            var enrollees = Enrollee.CreateEnrollees(20);
            
            Console.WriteLine("ALL ENROLLEES");
            Enrollee.PrintEnrollees(enrollees);
            
            Console.WriteLine();
            Console.WriteLine("ALL ENROLLEES WITH AT LEAST 1 BAD MARK");
            Enrollee.PrintEnrollees(Enrollee.WithBadMarks(enrollees));
            
            Console.WriteLine();
            Console.WriteLine("The minimum exclusive average mark: ");
            if (!double.TryParse(Console.ReadLine(), out var minAverageMark))
                return;
            
            Console.WriteLine();
            Console.WriteLine("ALL CUSTOMERS WHOSE CARD NUMBERS ARE BETWEEN THE MIN AND MAX VALUES");
            Enrollee.PrintEnrollees(Enrollee.WhoseAverageMarkGreaterThan(enrollees, minAverageMark));
        }
    }
}
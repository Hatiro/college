using System;
using System.Diagnostics.CodeAnalysis;

namespace Task6
{
    internal static class Program
    {
        public static readonly string[] Diagnosis = { "Tuberculosis", "Pneumonia" };
        
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        private static void Main()
        {
            var patients = Patient.CreatePatients(20);
            
            Console.WriteLine("ALL PATIENTS");
            Patient.PrintPatients(patients);
            
            Console.WriteLine();
            Console.Write($"Input the name of diagnosis ({string.Join(", ", Diagnosis)}): ");
            var diagnosis = Console.ReadLine();
            Patient.PrintPatients(Patient.WithDiagnosis(patients, diagnosis));
        }
    }
}
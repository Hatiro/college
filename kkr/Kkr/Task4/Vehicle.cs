using System;
// ReSharper disable VirtualMemberNeverOverridden.Global
// ReSharper disable UnusedMember.Global

#pragma warning disable 659
namespace Task4
{
    internal abstract class Vehicle : IEquatable<Vehicle>
    {
        public string Model { get; set; }
        public string VehicleType { get; set; }
        public string FuelType { get; set; }
        public string Manufacturer { get; set; }

        public abstract void Drive();
        public abstract void Fuel();
        public abstract void Repair();

        public virtual void PrintModel()
        {
            Console.WriteLine($"Model: {Model}");
        }
        
        public override bool Equals(object obj)
        {
            return obj is Vehicle v && Equals(v);
        }

        public bool Equals(Vehicle vehicle)
        {
            return vehicle != null && Model == vehicle.Model;
        }
        
        public override string ToString()
        {
            return $"Model: {Model}" + Environment.NewLine +
                $"Vehicle type: {VehicleType}" + Environment.NewLine +
                $"Fuel type: {FuelType}" + Environment.NewLine +
                $"Manufacturer: {Manufacturer}";
        }
    }
}
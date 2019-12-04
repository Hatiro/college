using System;

// ReSharper disable VirtualMemberNeverOverridden.Global
// ReSharper disable UnusedMember.Global

#pragma warning disable 659
namespace Task7
{
    internal abstract class AirVehicle : IEquatable<AirVehicle>
    {
        public string Route { get; set; }

        public abstract void Fly();

        public virtual void SetRoute(string newRoute)
        {
            Route = newRoute ?? throw new ArgumentNullException(nameof(newRoute));
        }

        public virtual void PrintRoute()
        {
            Console.WriteLine(ToString());
        }
        
        public override bool Equals(object obj)
        {
            return obj is AirVehicle v && Equals(v);
        }

        public bool Equals(AirVehicle airVehicle)
        {
            return airVehicle != null && Route == airVehicle.Route;
        }
        
        public override string ToString()
        {
            return $"Route: {Route}";
        }
    }
}
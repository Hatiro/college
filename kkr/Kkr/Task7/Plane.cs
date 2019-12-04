using System;

namespace Task7
{
    internal sealed class Plane : AirVehicle
    {
        public override void Fly()
        {
            Console.WriteLine("Car was being flied.");
        }

        public override string ToString()
        {
            return "PLANE" + Environment.NewLine + base.ToString();
        }
    }
}
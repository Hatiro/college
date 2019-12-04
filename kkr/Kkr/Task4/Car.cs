using System;

namespace Task4
{
    internal sealed class Car : Vehicle
    {
        public override void Drive()
        {
            Console.WriteLine("Car was being driven.");
        }

        public override void Fuel()
        {
            Console.WriteLine("Car was fueled.");
        }

        public override void Repair()
        {
            Console.WriteLine("Car was repaired.");
        }

        public override string ToString()
        {
            return "CAR" + Environment.NewLine + base.ToString();
        }
    }
}
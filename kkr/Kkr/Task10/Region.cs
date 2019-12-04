using System;

// ReSharper disable VirtualMemberNeverOverridden.Global
// ReSharper disable UnusedMember.Global

#pragma warning disable 659
namespace Task10
{
    internal abstract class Region : IEquatable<Region>
    {
        public decimal Square { get; set; }

        public virtual void PrintInfo()
        {
            Console.WriteLine(ToString());
        }
        
        public override bool Equals(object obj)
        {
            return obj is Region r && Equals(r);
        }

        public bool Equals(Region region)
        {
            return region != null && Square == region.Square;
        }
        
        public override string ToString()
        {
            return $"Total square: {Square}";
        }
    }
}
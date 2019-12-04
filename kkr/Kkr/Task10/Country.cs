using System;

namespace Task10
{
    internal sealed class Country : Region
    {
        public string CapitalCity { get; set; }
        public int CountOfRegions { get; set; }
        public string[] CentersOfRegions { get; set; }
        
        public override string ToString()
        {
            return "COUNTRY" +
                   Environment.NewLine +
                   $"Capital city: {CapitalCity}" +
                   Environment.NewLine +
                   $"Count of regions: {CountOfRegions}" +
                   Environment.NewLine +
                   "List of centers of regions: " +
                   string.Join(", ", CentersOfRegions) +
                   Environment.NewLine +
                   base.ToString();
        }
    }
}
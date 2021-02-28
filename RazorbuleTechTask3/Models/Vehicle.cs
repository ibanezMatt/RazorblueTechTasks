using System.Collections.Generic;

namespace RazorbuleTechTask3.Models
{
    public class Vehicle : IEqualityComparer<Vehicle>
    {
        public string Registration { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Colour { get; set; }

        public FuelType FuelType { get; set; }

        public bool Equals(Vehicle x, Vehicle y)
        {
            return x.Registration == y.Registration;
        }

        public int GetHashCode(Vehicle obj)
        {
            return obj.Registration.GetHashCode();
        }
    }
}

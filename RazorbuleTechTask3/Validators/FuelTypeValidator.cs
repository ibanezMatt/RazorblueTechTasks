using System.Collections.Generic;
using System.Linq;
using RazorbuleTechTask3.Helpers;
using RazorbuleTechTask3.Models;

namespace RazorbuleTechTask3.Validators
{
    public static class FuelTypeValidator
    {
        private static readonly List<string> _validFuelTypes = new List<string>() { "Petrol", "Diesel", "Electric", "Hybrid" };

        // I spotted typographical errors on the Fuel field with the provided CSV
        // So I'm creating a validator that will create a fuel type object
        // This contains the validated value - which I will use to filter with
        // and the original value, which is what I will return to the appropriate CSVs when exported
        public static FuelType Validate(string value)
        {
            // Init Key/ Cost object List from distance function
            var costs = new List<LevenshteinCost>();

            _validFuelTypes.ForEach(fuelType =>
            {
                costs.Add(LevenshteinDistance.Compute(value, fuelType));
            });

            string closestKey = costs.Where(c => c.Cost == costs.Min(x => x.Cost)).FirstOrDefault().Key;

            return new FuelType
            {
                Key = closestKey,
                OriginalValue = value
            };
        }
    }
}

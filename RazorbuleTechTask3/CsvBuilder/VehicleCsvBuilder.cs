using System.Collections.Generic;
using RazorbuleTechTask3.Models;

namespace RazorbuleTechTask3.CsvBuilder
{
    public class VehicleCsvBuilder : CsvBuilder
    {
        private readonly string[] _headers = new string[] { "Car Registration", "Make", "Model", "Colour", "Fuel" };

        public VehicleCsvBuilder()
            : base()
        {
        }

        public void BuildValues(Vehicle vehicle)
        {
            BuildValue(vehicle.Registration);
            BuildValue(vehicle.Make);
            BuildValue(vehicle.Model);
            BuildValue(vehicle.Colour);
            BuildValue(vehicle.FuelType.OriginalValue, true);
        }

        public string Generate(List<Vehicle> vehicles)
        {
            BuildHeaders(_headers);

            vehicles.ForEach(vehicle =>
            {
                BuildValues(vehicle);
            });

            return _sb.ToString();
        }
    }
}

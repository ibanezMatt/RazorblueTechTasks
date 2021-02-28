using RazorbuleTechTask3.Models;
using RazorbuleTechTask3.Validators;

namespace RazorbuleTechTask3.VehicleBuilders
{
    public class VehicleBuilder
    {
        // we're expecting an array of values that I can map to a Vehicle
        // as a note for checking against the provided file, I may need to amend this function to further validate the data.
        public Vehicle Construct(string[] values)
        {
            return new Vehicle
            {
                Registration = values[0],
                Make = values[1],
                Model = values[2],
                Colour = values[3],
                FuelType = FuelTypeValidator.Validate(values[4])
            };
        }
    }
}

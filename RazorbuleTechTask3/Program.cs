using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RazorbuleTechTask3.CsvBuilder;
using RazorbuleTechTask3.FileReader;
using RazorbuleTechTask3.Models;
using RazorbuleTechTask3.Validators;
using RazorbuleTechTask3.VehicleBuilders;

namespace RazorbuleTechTask3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running data import, sort and export program.");

            List<Vehicle> vehicles = new List<Vehicle>();

            using (ReadFile reader = new ReadFile("RazorbuleTechTask3.Resources.Technical Test Data.csv"))
            {
                // skip the first line as these are headers
                var data = reader.ReadLine();

                VehicleBuilder builder = new VehicleBuilder();

                // while lines exist in the reader, iterate over
                while ((data = reader.ReadLine()) != null)
                {
                    // split the line by comma
                    var options = data.Split(',');
                    vehicles.Add(builder.Construct(options));
                }
            }

            // before continuing to use the dataset
            // we need to remove any non-distinct vehicles by their registration
            vehicles = vehicles.Distinct(new Vehicle()).ToList();

            Step1(vehicles);
            Step2(vehicles);

            Console.ReadKey();
        }

        private static void Step1(List<Vehicle> vehicles)
        {
            var csvBuilder = new VehicleCsvBuilder();

            // create lists of vehicles for each fuel type
            var dieselVehicles = vehicles.Where(v => v.FuelType.Key == "Diesel").ToList();
            var dieselCsv = csvBuilder.Generate(dieselVehicles);
            csvBuilder.ResetStringBuilder();

            var petrolVehicles = vehicles.Where(v => v.FuelType.Key == "Petrol").ToList();
            var petrolCsv = csvBuilder.Generate(petrolVehicles);
            csvBuilder.ResetStringBuilder();

            var electricVehicles = vehicles.Where(v => v.FuelType.Key == "Electric").ToList();
            var electricCsv = csvBuilder.Generate(electricVehicles);
            csvBuilder.ResetStringBuilder();

            var hybridVehicles = vehicles.Where(v => v.FuelType.Key == "Hybrid").ToList();
            var hybridCsv = csvBuilder.Generate(hybridVehicles);

            File.WriteAllText("Diesel Vehicles.csv", dieselCsv);
            File.WriteAllText("Petrol Vehicles.csv", petrolCsv);
            File.WriteAllText("Electric Vehicles.csv", electricCsv);
            File.WriteAllText("Hybrid Vehicles.csv", hybridCsv);
        }

        private static void Step2(List<Vehicle> vehicles)
        {
            // get my list of cars with valid registrations
            var validRegistrationVehicles = vehicles.Where(v => RegistrationValidator.Validate(v.Registration)).ToList();

            var csvBuilder = new VehicleCsvBuilder();

            var csv = csvBuilder.Generate(validRegistrationVehicles);
            File.WriteAllText("Valid Registration Vehicles.csv", csv);

            Console.WriteLine("All CSVs have been generated, and can be found within the 'bin' folder");

            Console.WriteLine($"The total count of vehicles with a valid registration is: {validRegistrationVehicles.Count}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorbuleTechTask3.CsvBuilder;
using RazorbuleTechTask3.Models;
using RazorbuleTechTask3.VehicleBuilders;

namespace RazorblueTechTaskTests.Task3
{
    [TestClass]
    public class VehicleCsvBuilerTests
    {
        private VehicleCsvBuilder _builder;

        [TestInitialize]
        public void TestInitialize()
        {
            _builder = new VehicleCsvBuilder();
        }

        [TestMethod]
        public void ShouldReturnStringOfHeaders()
        {
            string expected = "Car Registration,Make,Model,Colour,Fuel\r\n";

            var result = _builder.Generate(new List<Vehicle>());

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldReturnStringOfHeaders_And_OneVehicle()
        {
            Vehicle vehicle = new VehicleBuilder().Construct(new string[] { "HD12 REM", "Ford", "Mustang", "Black", "Petrol" });
            string expected = "Car Registration,Make,Model,Colour,Fuel\r\nHD12 REM,Ford,Mustang,Black,Petrol\r\n";

            var result = _builder.Generate(new List<Vehicle>() { vehicle });

            Assert.AreEqual(expected, result);
        }
    }
}

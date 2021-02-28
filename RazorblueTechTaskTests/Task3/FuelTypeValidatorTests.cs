using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorbuleTechTask3.Models;
using RazorbuleTechTask3.Validators;

namespace RazorblueTechTaskTests.Task3
{
    [TestClass]
    public class FuelTypeValidatorTests
    {
        [TestMethod]
        public void ShouldReturnPetrol()
        {
            var valueToCheck = "peetral";
            var expected = new FuelType
            {
                Key = "Petrol",
                OriginalValue = valueToCheck
            };

            var result = FuelTypeValidator.Validate(valueToCheck);

            Assert.AreEqual(expected.Key, result.Key);
            Assert.AreEqual(expected.OriginalValue, result.OriginalValue);
        }

        [TestMethod]
        public void ShouldReturnDiesel()
        {
            var valueToCheck = "daesal";
            var expected = new FuelType
            {
                Key = "Diesel",
                OriginalValue = valueToCheck
            };

            var result = FuelTypeValidator.Validate(valueToCheck);

            Assert.AreEqual(expected.Key, result.Key);
            Assert.AreEqual(expected.OriginalValue, result.OriginalValue);
        }

        [TestMethod]
        public void ShouldReturnElectric()
        {
            var valueToCheck = "eclectic";
            var expected = new FuelType
            {
                Key = "Electric",
                OriginalValue = valueToCheck
            };

            var result = FuelTypeValidator.Validate(valueToCheck);

            Assert.AreEqual(expected.Key, result.Key);
            Assert.AreEqual(expected.OriginalValue, result.OriginalValue);
        }

        [TestMethod]
        public void ShouldReturnHybrid()
        {
            var valueToCheck = "hybd";
            var expected = new FuelType
            {
                Key = "Hybrid",
                OriginalValue = valueToCheck
            };

            var result = FuelTypeValidator.Validate(valueToCheck);

            Assert.AreEqual(expected.Key, result.Key);
            Assert.AreEqual(expected.OriginalValue, result.OriginalValue);
        }
    }
}

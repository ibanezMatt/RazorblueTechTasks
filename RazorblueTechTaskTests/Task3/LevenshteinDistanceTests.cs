using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorbuleTechTask3.Helpers;
using RazorbuleTechTask3.Models;

namespace RazorblueTechTaskTests.Task3
{
    [TestClass]
    public class LevenshteinDistanceTests
    {
        [TestMethod]
        public void ShouldReturnKeyAndCostOfOne()
        {
            string validOpt = "Cheese";
            string optToValidate = "Chaese";
            var expected = (validOpt, 1);

            LevenshteinCost result = LevenshteinDistance.Compute(optToValidate, validOpt);

            Assert.AreEqual(expected.Item2, result.Cost);
            Assert.AreEqual(expected.validOpt, result.Key);
        }

        [TestMethod]
        public void ShouldReturnCostOfSeventeen()
        {
            string validOpt = "anthropomorphology";
            string optToValidate = "addddddddddddddddd";
            int expectedCost = 17;

            LevenshteinCost result = LevenshteinDistance.Compute(optToValidate, validOpt);

            Assert.AreEqual(expectedCost, result.Cost);
        }
    }
}

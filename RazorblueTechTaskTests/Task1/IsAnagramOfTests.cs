using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorblueTechTask1;

namespace RazorblueTechTaskTests.Task1
{
    [TestClass]
    public class IsAnagramOfTests
    {
        [TestMethod]
        public void SingleWord_ShouldReturnTrue()
        {
            string firstValue = "aligned";
            string secondValue = "dealing";

            bool result = firstValue.IsAnagramOf(secondValue);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShorterPhrase_ShouldReturnTrue()
        {
            string firstValue = "the eyes";
            string secondValue = "they see";

            bool result = firstValue.IsAnagramOf(secondValue);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LongerPhrase_ShouldReturnTrue()
        {
            string firstValue = "I am Lord Voldemort";
            string secondValue = "Tom Marvolo Riddle";

            bool result = firstValue.IsAnagramOf(secondValue);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SingleWorld_ShouldReturnFalse()
        {
            string firstValue = "Cheese";
            string secondValue = "Xylophone";

            bool result = firstValue.IsAnagramOf(secondValue);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShorterPhrase_ShouldReturnFalse()
        {
            string firstValue = "Selling swords";
            string secondValue = "Sellsword";

            bool result = firstValue.IsAnagramOf(secondValue);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LongerPhrase_ShouldReturnFalse()
        {
            string firstValue = "Baking biscuits is fun";
            string secondValue = "Except when you burn them";

            bool result = firstValue.IsAnagramOf(secondValue);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AnagramContainsSpecialCharacters_ShouldReturnTrue()
        {
            string firstValue = "al!i@gn##ed";
            string secondValue = "dea/ li$ng@";

            bool result = firstValue.IsAnagramOf(secondValue);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void FirstValueIsNull_ShouldReturnFalse()
        {
            string firstValue = null;
            string secondValue = "Except when you burn them";

            bool result = firstValue.IsAnagramOf(secondValue);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SecondValueIsNull_ShouldReturnFalse()
        {
            string firstValue = "First Value";
            string secondValue = null;

            bool result = firstValue.IsAnagramOf(secondValue);

            Assert.IsFalse(result);
        }
    }
}

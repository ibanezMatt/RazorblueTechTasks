using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorbuleTechTask3.Validators;

namespace RazorblueTechTaskTests.Task3
{
    [TestClass]
    public class RegistrationValidatorTests
    {
        [TestMethod]
        public void ShouldReturnTrue_WithValue_NJ13_LXX()
        {
            Assert.IsTrue(RegistrationValidator.Validate("NJ13 LXX"));
        }

        [TestMethod]
        public void ShouldReturnFalse_WithValue_MD60XBA()
        {
            Assert.IsFalse(RegistrationValidator.Validate("MD60XBA"));
        }

        [TestMethod]
        public void ShouldReturnFalse_WithValue_B640_BBJ()
        {
            Assert.IsFalse(RegistrationValidator.Validate("B640 BBJ"));
        }

        [TestMethod]
        public void ShouldReturnFalse_WithValue_NDJ64_XYZ()
        {
            Assert.IsFalse(RegistrationValidator.Validate("NDJ64 XYZ"));
        }

        [TestMethod]
        public void ShouldReturnFalse_WithValue_NDR_543R()
        {
            Assert.IsFalse(RegistrationValidator.Validate("NDR 543R"));
        }

        [TestMethod]
        public void ShouldReturnFalse_WithValue_ND05_BFRT()
        {
            Assert.IsFalse(RegistrationValidator.Validate("ND05 BFRT"));
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RazorblueTechTask2.Repositories.Interfaces;
using RazorblueTechTask2.Services;

namespace RazorblueTechTaskTests.Task2.ServiceTests
{
    [TestClass]
    public class IpWhiteListServiceTests
    {
        private Mock<IIpWhitelistRepository> _repository;
        private IpWhitelistService _service;

        [TestInitialize]
        public void TestInitialize()
        {
            _repository = new Mock<IIpWhitelistRepository>();
            _service = new IpWhitelistService(_repository.Object);
        }

        [TestMethod]
        public async Task WhenIpIsWhitelisted_ShouldReturnTrue_AndNotCallGetIpRanges()
        {
            _repository.Setup(r => r.GetIsIpWhitelistedAsync(It.IsAny<string>())).ReturnsAsync(true);
            _repository.Setup(r => r.GetIpRangesAsync());

            bool result = await _service.GetIsIpWhitelistedAsync(It.IsAny<string>());

            _repository.Verify(r => r.GetIpRangesAsync(), Times.Never);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task WhenGetIsIpWhitelisted_ReturnsFalse_ShouldCallGetIpRanges_And_ReturnTrue()
        {
            var ipList = new List<string>
            {
                "192.168.1.0/24",
                "154.1.0.1/24",
                "2.6.1.9-91.17.14.5"
            };

            var ipAddress = "192.168.1.176";

            _repository.Setup(r => r.GetIsIpWhitelistedAsync(It.IsAny<string>())).ReturnsAsync(false);
            _repository.Setup(r => r.GetIpRangesAsync()).ReturnsAsync(ipList);

            bool result = await _service.GetIsIpWhitelistedAsync(ipAddress);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task WhenGetIsIpWhitelisted_ReturnsFalse_ShouldCallGetIpRanges_And_ReturnFalse()
        {
            var ipList = new List<string>
            {
                "192.168.1.0/24",
                "154.1.0.1/24",
                "2.6.1.9-91.17.14.5"
            };

            var ipAddress = "192.168.178.176";

            _repository.Setup(r => r.GetIsIpWhitelistedAsync(It.IsAny<string>())).ReturnsAsync(false);
            _repository.Setup(r => r.GetIpRangesAsync()).ReturnsAsync(ipList);

            bool result = await _service.GetIsIpWhitelistedAsync(ipAddress);

            Assert.IsFalse(result);
        }
    }
}

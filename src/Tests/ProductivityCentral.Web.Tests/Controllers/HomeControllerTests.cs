using Moq;
using NUnit.Framework;
using ProductivityCentral.Web.Controllers;
using ProductivityCentral.Web.Services;
using System;

namespace ProductivityCentral.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IOperatorReportService> mockOperatorReportService;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockOperatorReportService = this.mockRepository.Create<IOperatorReportService>();
        }

        private HomeController CreateHomeController()
        {
            return new HomeController(
                this.mockOperatorReportService.Object);
        }

        [Test]
        public void Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();

            // Act
            var result = homeController.Index();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void About_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();

            // Act
            var result = homeController.About();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Contact_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();

            // Act
            var result = homeController.Contact();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void OperatorReport_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();
            OperatorReportSearchCriteria searchCriteria = null;

            // Act
            var result = homeController.OperatorReport(
                searchCriteria);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void OperatorReportPost_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();
            OperatorReportSearchCriteria searchCriteria = null;

            // Act
            var result = homeController.OperatorReportPost(
                searchCriteria);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void OperatorProductivityData_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();

            // Act
            var result = homeController.OperatorProductivityData();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}

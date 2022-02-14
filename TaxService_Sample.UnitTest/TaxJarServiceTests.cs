using Moq;
using NUnit.Framework;

namespace TaxService_Sample.UnitTest
{
    public class TaxJarServiceTests
    {
        private Mock<IOrder> _mockOrder;

        [SetUp]
        public void Setup()
        {            
            _mockOrder = new Mock<IOrder>();
            _mockOrder.SetupGet(m => m.OrderTotal).Returns(1.00m);
            _mockOrder.SetupGet(m => m.PostalCode).Returns("33579");            
        }

        [Test]
        public void TaxJarServiceMakesProperCallToGetTax()
        {
            var mockCalc = new Mock<ITaxCalculator>();
            mockCalc.Setup(m => m.CalculateTax(null, null)).Returns(0.075m);
            var taxService = TaxServiceFactory.GetTaxService(TaxCalcProvider.TaxJar, _mockOrder.Object);
            var result = taxService.GetTax();

            Assert.IsTrue(result == 0.075m);
        }
    }
}

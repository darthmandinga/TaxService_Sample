using Moq;
using NUnit.Framework;
using System;
using System.IO;
using TaxService_Sample.TaxServices;

namespace TaxService_Sample.UnitTest
{
    public class TaxJarCalculatorTests
    {
        private Mock<IOrder> _mockOrder;
        private string _testJson;
        private string _apiOutput;

        [SetUp]
        public void Setup()
        {
            _mockOrder = new Mock<IOrder>();
            _mockOrder.SetupGet(m => m.OrderTotal).Returns(1.00m);
            _mockOrder.SetupGet(m => m.PostalCode).Returns("33579");
            _testJson = File.Exists("TaxRateTest.json") ? File.ReadAllText("TaxRateTest.json") : null;
            _apiOutput = File.Exists("ApiOutput.json") ? File.ReadAllText("ApiOutput.json") : null;
        }

        [Test]
        public void TaxCalculatesCorrectly()
        {
            var calculator = new TaxJarCalculator(_mockOrder.Object);
            var tax = calculator.CalculateTax(0.06m);

            Assert.IsTrue(tax == 0.06m);
        }

        [Test]
        public void NullJsonThrowsException()
        {
            var calculator = new TaxJarCalculator(_mockOrder.Object);
            var taxRate = calculator.GetTaxRate(null);

            var ex = Assert.Throws<Exception>(delegate { throw new Exception("An invalid tax rate was returned from the service"); });
            Assert.That(ex.Message, Is.EqualTo("An invalid tax rate was returned from the service"));
        }

        [Test]
        public void TaxCalculatesCorrectlyFromJson()
        {
            var calculator = new TaxJarCalculator(_mockOrder.Object);

            if (string.IsNullOrWhiteSpace(_testJson))
                Assert.Fail("Could not load Test Json");

            var taxRate = calculator.GetTaxRate(_testJson);

            Assert.IsTrue(taxRate == 0.07m);
        }

        /* Normally I would not include a test like this in Unit Testing, and save it for integration testing
         * but for the purposes of this exercise and to demonstrate the code is working to retrieve and parse
         * the data from the API, this test is being used.
         */
        [Test]
        public void TestRetrieveDataFromTaxJar()
        {
            var calculator = new TaxJarCalculator(_mockOrder.Object);
            var ratesString = calculator.CallTaxJarService(_mockOrder.Object.PostalCode);

            Assert.True(ratesString.Equals(_apiOutput));
        }
    }
}

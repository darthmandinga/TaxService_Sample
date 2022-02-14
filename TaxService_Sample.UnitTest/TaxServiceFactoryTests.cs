using Moq;
using NUnit.Framework;
using TaxService_Sample.TaxServices;

namespace TaxService_Sample.UnitTest
{
    public class TaxServiceFactoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestTaxServiceReturnsTaxJarWithTaxJarParam()
        {
            var taxService = TaxServiceFactory.GetTaxService(TaxCalcProvider.TaxJar, new Mock<IOrder>().Object);
            Assert.IsTrue(taxService is TaxJarService);
        }

        [Test]
        public void TestTaxServiceReturnsDefaultWithDefaultParam()
        {
            var taxService = TaxServiceFactory.GetTaxService(TaxCalcProvider.Default, new Mock<IOrder>().Object);
            Assert.IsTrue(taxService is TaxJarService);
        }
    }
}

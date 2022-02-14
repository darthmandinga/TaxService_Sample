using Moq;
using NUnit.Framework;
using TaxService_Sample.TaxServices;

namespace TaxService_Sample.UnitTest
{
    public class TaxCalculatorFactoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestTaxCalculatorReturnsTaxJarWithTaxJarParam()
        {
            var taxCalc = TaxCalculatorFactory.GetTaxCalculator(TaxCalcProvider.TaxJar, new Mock<IOrder>().Object);
            Assert.IsTrue(taxCalc is TaxJarCalculator);            
        }

        [Test]
        public void TestTaxCalculatorReturnsDefaultWithDefaultParam()
        {
            var taxCalc = TaxCalculatorFactory.GetTaxCalculator(TaxCalcProvider.Default, new Mock<IOrder>().Object);
            Assert.IsTrue(taxCalc is TaxJarCalculator);
        }
    }
}
using NUnit.Framework;
using System.IO;
using TaxService_Sample.TaxServices;

namespace TaxService_Sample.UnitTest
{
    public class TaxJarRateTests
    {
        private string _testJson;

        [SetUp]
        public void Setup()
        {
            _testJson = File.Exists("TaxRateTest.json") ? File.ReadAllText("TaxRateTest.json") : null;
        }

        [Test]
        public void Test1()
        {
            if (string.IsNullOrWhiteSpace(_testJson))
                Assert.Fail("Could not load Test Json");

            var taxRate = TaxJarRate.Deserialize(_testJson);

            Assert.True(taxRate.RateProps.Zip == "05495-2086");
            Assert.True(taxRate.RateProps.Country == "US");
            Assert.True(taxRate.RateProps.CountryRate == "0.0");
            Assert.True(taxRate.RateProps.State == "VT");
            Assert.True(taxRate.RateProps.StateRate == "0.06");
            Assert.True(taxRate.RateProps.County == "CHITTENDEN");
            Assert.True(taxRate.RateProps.CountyRate == "0.0");
            Assert.True(taxRate.RateProps.City == "WILLISTON");
            Assert.True(taxRate.RateProps.CityRate == "0.0");
            Assert.True(taxRate.RateProps.CombinedDistrictRate == "0.01");
            Assert.True(taxRate.RateProps.CombinedRate == "0.07");
            Assert.True(taxRate.RateProps.FreightTaxable == true);
        }
    }
}

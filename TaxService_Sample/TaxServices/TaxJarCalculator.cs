using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TaxService_Sample.TaxServices
{
    internal class TaxJarCalculator : ITaxCalculator
    {
        private const string _apiKey = "5da2f821eee4035db4771edab942a4cc";
        private readonly string _baseUri;
        private readonly IOrder _order;

        /// <summary>
        /// Default constructor for the TaxJarCalculator
        /// </summary>
        /// <param name="baseUri">Optional injected base uri for the service</param>
        public TaxJarCalculator(IOrder order, string baseUri = null)
        {
            _baseUri = string.IsNullOrWhiteSpace(baseUri) ? "https://api.taxjar.com/v2/rates/" : baseUri;
            _order = order;
        }

        /// <summary>
        /// Calculate the tax for an order
        /// </summary>
        /// <param name="rate">The optional injectible rate for overriding or unit testing</param>
        /// <param name="ratesJson">optional, injectable parameter for the rates retrieved from another service and for unit testing</param>
        /// <returns>The total tax for the order</returns>
        public decimal CalculateTax(decimal? rate = null, string ratesJson = null)
        {
            rate ??= GetTaxRate(ratesJson);

            return _order.OrderTotal * rate.Value;
        }

        /// <summary>
        /// Gets the tax rate based on parameters of the order
        /// </summary>
        /// <param name="ratesJson">optional, injectable parameter for the rates retrieved from another service and for unit testing</param>
        /// <returns>returns the tax rate</returns>
        public decimal GetTaxRate(string ratesJson = null)
        {
            ratesJson ??= CallTaxJarService(_order.PostalCode);
            var taxRates = TaxJarRate.Deserialize(ratesJson);

            if (string.IsNullOrWhiteSpace(taxRates?.RateProps?.CombinedRate))
                throw new Exception("An invalid tax rate was returned from the service");
                
            return decimal.Parse(taxRates?.RateProps?.CombinedRate);
        }

        /* For simplicity I am putting this here, but I would have a library to handle external calls like thisl
         * As a result this is public, to mimic that, and make this testable in the unit tests. */
        /// <summary>
        /// Calls the TaxJar Service and gets the JSON string back with rate information
        /// </summary>
        /// <param name="postalCode">The postal code to use for retrieving the data</param>
        /// <returns>A JSON payload with tax rate data based on order parameters</returns>
        public string CallTaxJarService(string postalCode)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            var result = client.GetAsync(string.Format("{0}{1}", _baseUri, postalCode)).Result;

            using var sr = new StreamReader(result.Content.ReadAsStreamAsync().Result);
            return sr.ReadToEnd();
        }
    }
}

namespace TaxService_Sample
{
    public interface ITaxCalculator
    {
        /// <summary>
        /// Calculates the tax for an order based on the tax provider
        /// </summary>
        /// <param name="rate">The injectible rate value for overrding or unit testing</param>
        /// <param name="ratesJson">optional, injectable parameter for the rates retrieved from another service and for unit testing</param>
        /// <returns>The total tax for the order</returns>
        decimal CalculateTax(decimal? rate = null, string ratesJson = null);
    }
}

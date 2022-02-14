using TaxService_Sample.TaxServices;

namespace TaxService_Sample
{
    public static class TaxCalculatorFactory
    {
        /// <summary>
        /// Get the implementation of the Tax Calculator for the requested provider
        /// </summary>
        /// <param name="provider">The tax calculation provider</param>
        /// <param name="order">The Order being calculated</param>
        /// <returns>A concrete Tax Calculator implementation</returns>
        public static ITaxCalculator GetTaxCalculator(TaxCalcProvider provider, IOrder order)
        {
            return provider switch
            {
                TaxCalcProvider.TaxJar => new TaxJarCalculator(order),
                _ => new TaxJarCalculator(order),
            };
        }
    }
}

using TaxService_Sample.TaxServices;

namespace TaxService_Sample
{
    public static class TaxServiceFactory
    {
        /// <summary>
        /// Gets the implementation of the Tax Service for the requested provider
        /// </summary>
        /// <param name="provider">The tax service provider to use</param>
        /// <param name="order">The Order being calculated</param>
        /// <param name="calculator">The optional tax calculator to inject</param>
        /// <returns>A concrete Tax Service implementation</returns>
        public static ITaxService GetTaxService(TaxCalcProvider provider, IOrder order, ITaxCalculator calculator = null)
        {
            return provider switch
            {
                TaxCalcProvider.TaxJar => new TaxJarService(order, calculator),
                _ => new TaxJarService(order, calculator),
            };
        }
    }
}

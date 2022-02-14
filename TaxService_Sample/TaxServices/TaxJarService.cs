namespace TaxService_Sample.TaxServices
{
    internal class TaxJarService : ITaxService
    {
        private readonly ITaxCalculator _taxCalculator;

        /// <summary>
        /// TaxJar Service Constructor
        /// </summary>
        /// <param name="order">The Order being calculated</param>
        /// <param name="taxCalculator">The optional concrete implementation of the tax calculator to use</param>
        public TaxJarService(IOrder order, ITaxCalculator taxCalculator = null)
        {
            _taxCalculator = taxCalculator ?? TaxCalculatorFactory.GetTaxCalculator(TaxCalcProvider.TaxJar, order);
        }

        /// <summary>
        /// Gets the total tax for an Order
        /// </summary>
        /// <param name="order">The order to get the tax for</param>
        /// <returns>The total tax of the order</returns>
        public decimal GetTax()
        {
            return _taxCalculator.CalculateTax();
        }
    }
}

namespace TaxService_Sample
{
    public interface ITaxService
    {
        /// <summary>
        /// Gets the total tax for an order from one of the tax providers
        /// </summary>
        /// <param name="order">The order to get the tax for</param>
        /// <returns>The total tax for the order</returns>
        decimal GetTax();
    }
}

namespace TaxService_Sample
{
    /// <summary>
    /// Simple Order Interface
    /// </summary>
    public interface IOrder
    {
        /* For the sake of simplicity for this exercise, I am leaving out
         * any major composition items such as address objects, customer objects
         * and so on to comprise an Order object */

        /// <summary>
        /// The total amount of the order minus tax
        /// </summary>
        decimal OrderTotal { get; set; }
        /// <summary>
        /// The postal code of the order
        /// </summary>
        string PostalCode { get; set; }
        /// <summary>
        /// The customer's name who placed the order
        /// </summary>
        string CustomerName { get; set; }
    }
}

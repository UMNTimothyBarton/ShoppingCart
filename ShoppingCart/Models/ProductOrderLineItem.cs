namespace ShoppingCart.Models
{
    /// <summary>
    /// Represents the item and quantity of the product order.
    /// </summary>
    public class ProductOrderLineItem
    {
        /// <summary>
        /// Gets or sets the internal product Id being ordered.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product quantity being ordered.
        /// </summary>
        public int Quantity { get; set; }
    }
}

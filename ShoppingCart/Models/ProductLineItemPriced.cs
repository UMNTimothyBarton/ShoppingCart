using System;
using System.Text.Json.Serialization;

namespace ShoppingCart.Models
{
    /// <summary>
    /// Represents a calculated price for the given product and quantity.
    /// </summary>
    public class ProductLineItemPriced
    {
        private const double SALESTAXRATE = .1;
        private const double IMPORTDUTYRATE = .05;

        /// <summary>
        /// Gets or sets a reference to the product and quantity being ordered.
        /// </summary>
        public ProductOrderLineItem LineItem { get; set; }

        /// <summary>
        /// Gets or sets the item price of the product.
        /// </summary>
        public double ItemPrice { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the item
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Gets or sets whether the product is domestically made or import, defaulting to true.  If not domestic, it will be subject to import duty.
        /// </summary>
        [JsonIgnore]
        public bool IsDomestic { get; set; } = true;

        /// <summary>
        /// Gets or sets whether the item is subject to sales tax.  Defaults to true.
        /// </summary>
        [JsonIgnore]
        public bool IsSalesTaxable { get; set; } = true;

        /// <summary>
        /// If subject to sales tax, calculates the sales tax on the item type, multiplying the quantity, item price and current sales tax rate.  Otherwise returns zero.
        /// </summary>
        public double SalesTax
        {
            get
            {
                return IsSalesTaxable ? RoundToNearestFiveCents(LineItem.Quantity * ItemPrice * SALESTAXRATE) : 0;
            }
        }

        /// <summary>
        /// If subject to import tax, returns the tax amount based on the item price and quantity. Otherwise returns zero.
        /// </summary>
        public double ImportTax
        {
            get
            {
                return IsDomestic ? 0 : RoundToNearestFiveCents(LineItem.Quantity * ItemPrice * IMPORTDUTYRATE);
            }
        }

        /// <summary>
        /// Rounds the price to the nearest five cents, rounding up.
        /// </summary>
        /// <param name="price">The price being rounded.</param>
        /// <returns>The price rounded up to the nearest multiple of five cents.</returns>
        private static double RoundToNearestFiveCents(double price)
        {
            return Math.Ceiling((double)(price * 20)) / 20;
        }
    }
}

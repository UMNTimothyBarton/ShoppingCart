using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShoppingCart.Models
{
    /// <summary>
    /// Represents the information about an available product.
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// The internal identifier of the product.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The consumer facing product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The current per-item price of the product.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the product description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Determines of the product is subject to import duty or not (it does not if it is a domestic product).
        /// </summary>
        [JsonIgnore]
        internal bool IsDomestic { get; set; } = true;

        /// <summary>
        /// Gets or sets whether the product is subject to sales tax.
        /// </summary>
        [JsonIgnore]
        internal bool IsSalesTaxable { get; set; } = true;
    }
}

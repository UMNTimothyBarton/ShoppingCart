using ShoppingCart.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.Repositories
{
    /// <summary>
    /// The interface used for retrieving products.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Retrieves all available products.
        /// </summary>
        /// <returns>A list of all products within the database.</returns>
        public List<ProductModel> GetAllProducts();

        /// <summary>
        /// Retrieves a specific product given the identifier.
        /// </summary>
        /// <param name="productId">The product id being searched for.</param>
        /// <returns>A task promising the product model result.</returns>
        public ValueTask<ProductModel> GetProductAsync(int productId);
    }
}

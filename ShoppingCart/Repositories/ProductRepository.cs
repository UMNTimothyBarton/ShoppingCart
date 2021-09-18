using ShoppingCart.DatabaseContexts;
using ShoppingCart.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Repositories
{
    /// <summary>
    /// Creates the product repository to find all or specific product information.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly ShoppingCartContext _shoppingContext;

        /// <summary>
        /// Creates the repository given the database context.
        /// </summary>
        /// <param name="context">The current application context.</param>
        public ProductRepository(ShoppingCartContext context)
        {
            _shoppingContext = context;
        }

        /// <summary>
        /// Retrieves all available products.
        /// </summary>
        /// <returns>A list of all products within the database.</returns>
        public List<ProductModel> GetAllProducts()
        {
           return _shoppingContext.Products.AsEnumerable().ToList();
        }

        /// <summary>
        /// Retrieves a specific product given the identifier.
        /// </summary>
        /// <param name="productId">The product id being searched for.</param>
        /// <returns>A task promising the product model result.</returns>
        public ValueTask<ProductModel> GetProductAsync(int productId)
        {
            return _shoppingContext.Products.FindAsync(productId);
        }
    }
}

using ShoppingCart.DatabaseContexts;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ShoppingCartContext _shoppingContext;

        public ProductRepository(ShoppingCartContext context)
        {
            _shoppingContext = context;
        }

        public List<ProductModel> GetAllProducts()
        {
           return _shoppingContext.Products.AsEnumerable().ToList();
        }

        public ValueTask<ProductModel> GetProductAsync(int productId)
        {
            return _shoppingContext.Products.FindAsync(productId);
        }
    }
}

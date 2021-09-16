using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> products = new();
            products.Add(new ProductModel() { Id = 1, Name = "Skittles", Description = "Taste the rainbow.", Price = 15.99 });
            return products;
        }

        public ProductModel GetProduct(int productId)
        {
            return GetAllProducts().FirstOrDefault(x => x.Id.Equals(productId));
        }
    }
}

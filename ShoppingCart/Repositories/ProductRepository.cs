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
            int numberOfProducts = 6;

            List<ProductModel> products = new();

            for (int i = 1; i <= numberOfProducts; i++)
            {
                products.Add(new ProductModel() { Id = i, Name = String.Format("Skittles {0}", i), Description = "Taste the rainbow.", Price = 15.99 });
            }

            return products;
        }

        public ProductModel GetProduct(int productId)
        {
            return GetAllProducts().FirstOrDefault(x => x.Id.Equals(productId));
        }
    }
}

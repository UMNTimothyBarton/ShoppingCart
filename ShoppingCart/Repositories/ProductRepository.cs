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

            products.Add(new ProductModel() { Id = 1, Name = "Skittles (16 lb)", Description = "Taste the rainbow.", Price = 16.00, IsSalesTaxable = false });
            products.Add(new ProductModel() { Id = 2, Name = "Walkman", Description = "Listen on the go", Price = 99.99 });
            products.Add(new ProductModel() { Id = 3, Name = "Microwave Popcorn (1 bag)", Description = "Tastes like the movies.", Price = 0.99, IsSalesTaxable = false });
            products.Add(new ProductModel() { Id = 4, Name = "Vanilla Hazelnut Coffee", Description = "Skip the coffee shop.", Price = 11.00, IsSalesTaxable = false, IsDomestic = false });
            products.Add(new ProductModel() { Id = 5, Name = "Vespa", Description = "Ride in style", Price = 15001.25, IsDomestic = false });
            products.Add(new ProductModel() { Id = 6, Name = "Almond Snickers (1 crate imported)", Description = "You're not you when you're hungry.", Price = 75.99, IsSalesTaxable = false, IsDomestic = false });
            products.Add(new ProductModel() { Id = 7, Name = "Discman", Description = "Scratching discs before it was cool.", Price = 55.00 });
            products.Add(new ProductModel() { Id = 8, Name = "Bottle of Imported Wine", Description = "The rose colored glasses of life - F. Scott Fitzgerald", Price = 10.00, IsDomestic = false });
            products.Add(new ProductModel() { Id = 9, Name = "Fair Trade Coffee (300 lb. bag)", Description = "Love is in the air, and it smells like coffee.", Price = 997.99, IsSalesTaxable = false });

            return products;
        }

        public ProductModel GetProduct(int productId)
        {
            return GetAllProducts().FirstOrDefault(x => x.Id.Equals(productId));
        }
    }
}

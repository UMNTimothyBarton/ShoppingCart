using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.DatabaseContexts
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) : base(options)
        {
        }

        public DbSet<ProductModel> Products { get; set; }

        internal static void Initialize(ShoppingCartContext context)
        {
            context.Database.EnsureCreated();

            if (!(context.Products.Count() > 0))
            {
                context.Products.Add(new ProductModel() { Id = 1, Name = "Skittles (16 lb)", Description = "Taste the rainbow.", Price = 16.00, IsSalesTaxable = false });
                context.Products.Add(new ProductModel() { Id = 2, Name = "Walkman", Description = "Listen on the go", Price = 99.99 });
                context.Products.Add(new ProductModel() { Id = 3, Name = "Microwave Popcorn (1 bag)", Description = "Tastes like the movies.", Price = 0.99, IsSalesTaxable = false });
                context.Products.Add(new ProductModel() { Id = 4, Name = "Vanilla Hazelnut Coffee", Description = "Skip the coffee shop.", Price = 11.00, IsSalesTaxable = false, IsDomestic = false });
                context.Products.Add(new ProductModel() { Id = 5, Name = "Vespa", Description = "Ride in style", Price = 15001.25, IsDomestic = false });
                context.Products.Add(new ProductModel() { Id = 6, Name = "Almond Snickers (1 crate imported)", Description = "You're not you when you're hungry.", Price = 75.99, IsSalesTaxable = false, IsDomestic = false });
                context.Products.Add(new ProductModel() { Id = 7, Name = "Discman", Description = "Scratching discs before it was cool.", Price = 55.00 });
                context.Products.Add(new ProductModel() { Id = 8, Name = "Bottle of Imported Wine", Description = "The rose colored glasses of life - F. Scott Fitzgerald", Price = 10.00, IsDomestic = false });
                context.Products.Add(new ProductModel() { Id = 9, Name = "Fair Trade Coffee (300 lb. bag)", Description = "Love is in the air, and it smells like coffee.", Price = 997.99, IsSalesTaxable = false });
            }

            context.SaveChanges();
        }
    }
}

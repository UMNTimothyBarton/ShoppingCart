using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Repositories
{
    public interface IProductRepository
    {
        public List<ProductModel> GetAllProducts();

        public ProductModel GetProduct(int productId);
    }
}

using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.Controllers
{
    /// <summary>
    /// Controller for shopping cart functions such as calculating item prices.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private IProductRepository _productRepository;

     
        /// <summary>
        /// Constructor which initializes the controller based on the product repository.
        /// </summary>
        /// <param name="productRepository">Resolves the product repository being currently used.</param>
        public ShoppingCartController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Calculates the price and taxes on each of the items in the cart.
        /// </summary>
        /// <param name="cartItems">A list of all of the product Id's and quantities to calculate.</param>
        /// <returns>A list of each corresponding item with their price and taxes.</returns>
        [HttpPost("CalculateLineItems")]
        public async Task<List<ProductLineItemPriced>> CalculateLineItems([FromBody] List<ProductOrderLineItem> cartItems)
        {
            List<ProductLineItemPriced> response = new();

            foreach (ProductOrderLineItem item in cartItems)
            {
                ProductLineItemPriced priced = new() { LineItem = item };
                ProductModel productInfo = await _productRepository.GetProductAsync(item.ProductId);
                priced.ItemPrice = productInfo.Price * item.Quantity;
                priced.IsDomestic = productInfo.IsDomestic;
                priced.IsSalesTaxable = productInfo.IsSalesTaxable;
                priced.ItemName = productInfo.Name;
                response.Add(priced);
            }

            return response;
        }

        /// <summary>
        /// Returns a list of all available products within the system.
        /// </summary>
        /// <returns>A list of all products.</returns>
        [HttpGet("GetAllProducts")]
        public List<ProductModel> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
    }
}

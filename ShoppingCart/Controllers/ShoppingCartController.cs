﻿using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private IProductRepository _productRepository;
        public ShoppingCartController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("CalculateLineItems")]
        public List<ProductLineItemPriced> CalculateLineItems([FromBody] List<ProductOrderLineItem> cartItems)
        {
            List<ProductLineItemPriced> response = new();

            foreach (ProductOrderLineItem item in cartItems)
            {
                ProductLineItemPriced priced = new() { LineItem = item };
                ProductModel productInfo = _productRepository.GetProduct(item.ProductId);
                priced.ItemPrice = productInfo.Price * item.Quantity;
                priced.IsDomestic = productInfo.IsDomestic;
                priced.IsSalesTaxable = productInfo.IsSalesTaxable;
                priced.ItemName = productInfo.Name;
                response.Add(priced);
            }

            return response;
        }

        [HttpGet("GetAllProducts")]
        public List<ProductModel> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
    }
}

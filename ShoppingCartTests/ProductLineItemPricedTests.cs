using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Models;

namespace ShoppingCartTests
{
    [TestClass]
    public class ProductLineItemPricedTests
    {
        private const double _untaxedItemPrice = 16.00;

        private ProductOrderLineItem _dummyLineItem;

        private ProductLineItemPriced _dummyDomesticUntaxedItem;

        public ProductLineItemPricedTests()
        {
            _dummyLineItem = new ProductOrderLineItem() { ProductId = 1, Quantity = 1 };
            _dummyDomesticUntaxedItem = new ProductLineItemPriced() { LineItem = _dummyLineItem, ItemName = "Test Item", ItemPrice = _untaxedItemPrice, IsDomestic = true, IsSalesTaxable = false };
        }

        [TestMethod]
        public void TestDomesticUntaxedUnitPriceNotChanged()
        {
            Assert.AreEqual(_dummyDomesticUntaxedItem.ItemPrice, _untaxedItemPrice);
        }
    }
}

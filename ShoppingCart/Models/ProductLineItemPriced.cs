﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class ProductLineItemPriced
    {
        public ProductOrderLineItem LineItem { get; set; }

        public double ItemPrice { get; set; }

        [JsonIgnore]
        internal bool IsDomestic { get; set; } = true;

        [JsonIgnore]
        internal bool IsSalesTaxable { get; set; } = true;

        public double SalesTax
        {
            get
            {
                return IsSalesTaxable ? RoundToNearestFiveCents(LineItem.Quantity * ItemPrice * .05) : 0;
            }
        }

        public double ImportTax
        {
            get
            {
                return IsDomestic ? 0 : RoundToNearestFiveCents(LineItem.Quantity * ItemPrice * .1);
            }
        }

        private static double RoundToNearestFiveCents(double price)
        {
            return Math.Round(price * 20, MidpointRounding.AwayFromZero) / 20;
        }
    }
}
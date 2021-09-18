using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        internal bool IsDomestic { get; set; } = true;

        [JsonIgnore]
        internal bool IsSalesTaxable { get; set; } = true;
    }
}

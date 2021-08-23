using System;
using System.Collections.Generic;

#nullable disable

namespace eCommerceAPI.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public bool? Status { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace eCommerceAPI.Models
{
    public partial class OrderDetail
    {
        public string OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
    }
}

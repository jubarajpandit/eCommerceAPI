using System;
using System.Collections.Generic;

#nullable disable

namespace eCommerceAPI.Models
{
    public partial class PurchaseOrder
    {
        public string OrderId { get; set; }
        public DateTime Date { get; set; }
        public long CustomerId { get; set; }
        public decimal? Total { get; set; }
        public string Status { get; set; }
    }
}

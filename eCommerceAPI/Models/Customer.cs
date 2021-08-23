using System;
using System.Collections.Generic;

#nullable disable

namespace eCommerceAPI.Models
{
    public partial class Customer
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Pin { get; set; }
        public bool? Active { get; set; }
    }
}

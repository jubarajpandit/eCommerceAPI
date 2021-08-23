using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceAPI.Models;

namespace eCommerceAPI.IServices
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(Int64 id);
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        Customer DeleteCustomer(Int64 id);
    }
}

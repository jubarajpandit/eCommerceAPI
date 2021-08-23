using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceAPI.IServices;
using eCommerceAPI.Models;


namespace eCommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService customer)
        {
            customerService = customer;
        }

       
        [HttpGet]
        [Route("[action]")]        
        public IEnumerable<Customer>GetCustomers()
        {
           return customerService.GetCustomers();
        }

        [HttpGet]
        [Route("[action]")]
        public Customer GetCustomerById(Int64 id)
        {
            return customerService.GetCustomerById(id);
        }

        [HttpPost]
        [Route("[action]")]        
        public Customer AddCustomer(Customer customer)
        {
            return customerService.AddCustomer(customer);
        }

        [HttpPut]
        [Route("[action]")]        
        public Customer UpdateCustomer(Customer customer)
        {
            return customerService.UpdateCustomer(customer);
        }

        [HttpDelete]
        [Route("[action]")]        
        public Customer DeleteCustomer(Int64 id)
        {
            return customerService.DeleteCustomer(id);
        }
    }
}

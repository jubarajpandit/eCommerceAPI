using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceAPI.IServices;
using eCommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceAPI.Services
{
    public class CustomerService : ICustomerService
    {
        eCommercedbContext dbContext;
        public CustomerService(eCommercedbContext _db)
        {
            dbContext = _db;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var customers = dbContext.Customers.ToList();
            return customers;
        }

        public Customer GetCustomerById(Int64 id)
        {
            var customer = dbContext.Customers.FirstOrDefault(x => x.Id == id);
            return customer;
        }

        public Customer AddCustomer(Customer customer)
        {
            if(customer != null)
            {
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();
                return customer;
            }
            return null;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            if (customer != null)
            {
                dbContext.Entry(customer).State = EntityState.Modified;
                dbContext.SaveChanges();
                return customer;
            }
            return null;
        }

        public Customer DeleteCustomer(Int64 id)
        {

            var customer = dbContext.Customers.FirstOrDefault(x => x.Id == id);
            if(customer != null)
            {
                dbContext.Entry(customer).State = EntityState.Deleted;
                dbContext.SaveChanges();
            }            
            return customer;
        }

    }
}

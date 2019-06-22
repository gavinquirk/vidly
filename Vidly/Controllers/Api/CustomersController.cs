using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            // Return list of all customers
            return _context.Customers.ToList();
        }

        // GET /api/customers/1
        public Customer GetCustomer(int id)
        {
            // Get specified customer by id
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            // If customer not found, respond with Not Found
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // Return customer data
            return customer;
        }

        // POST /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            // If invalid, respond with Bad Request
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            // Add new customer to context, save and return
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        // PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            // If invalid, respond with Bad Request
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            // Find customer in database by id
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            // If customer not found, respond with Not Found
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            // Change db customer with new customer data
            // TODO: automapper
            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipType = customer.MembershipType;

            // Save changes
            _context.SaveChanges();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            // Find customer in database by id
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            // If customer not found, respond with Not Found
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            // Remove customer from memory, and save changes
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}

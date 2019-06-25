using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;

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
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            // Get specified customer by id
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            // If customer not found, respond with Not Found
            if (customer == null)
                return NotFound();

            // Return customer data
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            // If invalid, respond with Bad Request
            if (!ModelState.IsValid)
                return BadRequest();

            // Add new customer to context, save and return
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            // If invalid, respond with Bad Request
            if (!ModelState.IsValid)
                return BadRequest();

            // Find customer in database by id
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            // If customer not found, respond with Not Found
            if (customerInDb == null)
            {
                return NotFound();
            }

            // Change db customer with new customer data
            Mapper.Map(customerDto, customerInDb);

            // Save changes
            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            // Find customer in database by id
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            // If customer not found, respond with Not Found
            if (customerInDb == null)
            {
                return NotFound();
            }

            // Remove customer from memory, and save changes
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
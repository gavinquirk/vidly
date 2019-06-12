using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // Index View
        public ViewResult Index()
        {
            // Create customers list with GetCustomers
            var customers = GetCustomers();

            // Return view with customers list data
            return View(customers);
        }

        // Details Action
        public ActionResult Details(int id)
        {
            // Get customer with id param
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            // If no customer, return 404
            if (customer == null)
                return HttpNotFound();

            // Otherwise return view with single customer data
            return View(customer);
        }

        // Get List of Customers
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {Id = 1, Name = "Gavin Quirk" },
                new Customer {Id = 2, Name = "Bob Ross" }
            };
        }
    }
}
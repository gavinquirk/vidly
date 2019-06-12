using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // Index Action
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            // Return view with customers list data
            return View(customers);
        }

        // Details Action
        public ActionResult Details(int id)
        {
            // Get customer with id param
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            // If no customer, return 404
            if (customer == null)
                return HttpNotFound();

            // Otherwise return view with single customer data
            return View(customer);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TamilRockers.DataAccess;
using TamilRockers.Models;

namespace TamilRockers.Controllers
{
    public class CustomersController : Controller
    {
        TamilRockersDbContext context = null;

        public CustomersController()
        {
            context = new TamilRockersDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        
        public ActionResult Index()
        {
            var cQuery = context.Customers.Select(c => c);
            IEnumerable<Customer> customers = cQuery.ToList();
            return View(customers);
        }

        public ActionResult Detail(int id)
        {
            var customer = context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View("CustomerForm", customer);
        }

        [HttpPost]
        public ActionResult Save(Customer data)
        {
            if(!ModelState.IsValid)
            {
                return View("CustomerForm", data);
            }

            var customerDb = context.Customers.SingleOrDefault(c => c.Id == data.Id);
            if (customerDb != null)
            {
                customerDb.Name = data.Name;
                customerDb.Birthdate = data.Birthdate;

                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
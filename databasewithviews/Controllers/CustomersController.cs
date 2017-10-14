using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using databasewithviews.Models;

namespace databasewithviews.Controllers
{
    public class CustomersController : Controller
    {
        Organizationasp2Context MyDbContext=null;
        public CustomersController(Organizationasp2Context dbcontext)
        {
            MyDbContext = dbcontext;

        }
        public IActionResult main()
        {
            return View();
        }
        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult create(Customer C)
        {
            ViewBag.msg = "Customer is added";
            MyDbContext.Customer.Add(C);
            MyDbContext.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult allcust()
        {
            IList<Customer> c = MyDbContext.Customer.ToList<Customer>();
            return View(c);
        }
        public IActionResult detail(Customer c)
        {
            Customer cc = MyDbContext.Customer.Where(m => m.CustomerId == c.CustomerId).FirstOrDefault<Customer>();
            return View(cc);
        }
        public IActionResult delete(Customer c)
        {
            using (var t = MyDbContext.Database.BeginTransaction())
            {
                try
                {
                    MyDbContext.Customer.Remove(c);
                    MyDbContext.SaveChanges();
                    t.Commit();
                }
                catch(Exception e)
                {
                    t.Rollback();
                }
                return RedirectToAction(nameof(CustomersController.allcust));

            }
        }
        [HttpGet]
        public IActionResult edit(int CustomerId)
        {
            Customer c = MyDbContext.Customer.Where(m => m.CustomerId == CustomerId).FirstOrDefault<Customer>();
            return View(c);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult edit(Customer c)
        {
            MyDbContext.Customer.Attach(c);
            Customer cc = MyDbContext.Customer.Where(m => m.CustomerId == c.CustomerId).FirstOrDefault<Customer>();
            var entry = MyDbContext.Entry(cc);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            MyDbContext.SaveChanges();
            return RedirectToAction(nameof(CustomersController.allcust));
        }















    }
}
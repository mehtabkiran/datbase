using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using databasewithviews.Models;

namespace databasewithviews.Controllers
{
    public class EmployeesController : Controller
    {
        Organizationasp2Context MyDbContext = null;
        public EmployeesController(Organizationasp2Context dbcontext)
        {
            MyDbContext = dbcontext;
        }
        //string msg = "WELCOME TO THE MAIN PAGE";

        public IActionResult mainview()
        {
            ViewBag.message = "WELCOME TO THE MAIN PAGE";
            return View();
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
        public IActionResult create(Employee E)
        {
            MyDbContext.Employee.Add(E);
            MyDbContext.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult allemp()
        {
            IList<Employee> emp = MyDbContext.Employee.ToList<Employee>();
            return View(emp);

        }
        public IActionResult detail(Employee E)
        {
            Employee EE = MyDbContext.Employee.Where(m => m.EmpId == E.EmpId).FirstOrDefault<Employee>();
            return View(EE);
        }

        public IActionResult delete(Employee E)
        {
            using (var t= MyDbContext.Database.BeginTransaction())
            {
                try
                {
                    MyDbContext.Employee.Remove(E);

                    MyDbContext.SaveChanges();
                    t.Commit();
                }
                catch(Exception e)
                {
                    t.Rollback();
                }
            }

                return RedirectToAction(nameof(EmployeesController.allemp));
        }
        [HttpGet]
        public IActionResult edit(int EmpId)
        {
            Employee E = MyDbContext.Employee.Where(m => m.EmpId == EmpId).FirstOrDefault<Employee>();
            return View(E);
        }

        [HttpPost]
        public IActionResult edit(Employee E)
        {
            MyDbContext.Employee.Attach(E);
            Employee EE = MyDbContext.Employee.Where(m => m.EmpId == E.EmpId).FirstOrDefault<Employee>();
            var entry = MyDbContext.Entry(EE);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            MyDbContext.SaveChanges();
            return RedirectToAction(nameof(EmployeesController.allemp));

        }




    }
}
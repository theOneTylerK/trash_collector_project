using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        ApplicationDbContext db;
        public EmployeeController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Index(string searchInput)
        {
            List<Customer> filteredCustomers = new List<Customer>();
            DateTime today = DateTime.Now;
            var currentEmployee = User.Identity.GetUserId();
            var employee = db.Employees.Where(e => e.ApplicationUserId == currentEmployee).Single();
            if(searchInput == null)
            {
                filteredCustomers = db.Customers.Where(c => c.ZipCode == employee.ZipCode && c.PickUpDay == today.DayOfWeek.ToString() || c.ZipCode == employee.ZipCode && c.SpecialPickUpDate == today.Date.ToString()).ToList();
                foreach (Customer customer in filteredCustomers.ToList())
                {
                    if(customer.TempSuspendStart == null)
                    {
                        continue;
                    }
                    else
                    {
                        DateTime parsedStart = DateTime.Parse(customer.TempSuspendStart);
                        DateTime parsedEnd = DateTime.Parse(customer.TempSuspendEnd);
                        DateTime suspendMin = DateTime.MinValue;
                        suspendMin = parsedStart.Date;
                        DateTime suspendMax = DateTime.MaxValue;
                        suspendMax = parsedEnd.Date;
                        if (today.Date >= suspendMin && today.Date <= suspendMax)
                        {
                            filteredCustomers.Remove(customer);
                        }
                    }
                    
                }
            }
            else
            {
                filteredCustomers = db.Customers.Where(c => c.PickUpDay == searchInput && c.ZipCode == employee.ZipCode || c.ZipCode == employee.ZipCode && c.SpecialPickUpDate == today.Date.ToString()).ToList();
            }
            
            return View(filteredCustomers);
        }

        public ActionResult ViewCustomerProfile(int id)
        {
            var currentCustomer = db.Customers.Where(c => c.Id == id).Single();
            return View(currentCustomer);
        }

        public ActionResult ConfirmPickUp(int id)
        {
            double charge = 29.99;
            var currentCustomer = db.Customers.Where(c => c.Id == id).Single();
            currentCustomer.Balance += charge;
            db.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZipCode,FirstName,LastName,EmailAddress")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = User.Identity.GetUserId();
                employee.ApplicationUserId = currentUserId;
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }

            return View(employee);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZipCode,FirstName,LastName,EmailAddress")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }
            return View(employee);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
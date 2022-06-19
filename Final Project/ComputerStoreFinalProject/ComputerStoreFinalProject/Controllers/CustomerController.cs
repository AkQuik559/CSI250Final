using ComputerStoreFinalProject.Data;
using ComputerStoreFinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ComputerStoreFinalProject.Controllers
{
    public class CustomerController : Controller
    {
        private ComputerStoreDbContext _dbContext;
        public CustomerController(ComputerStoreDbContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            //Getting all customers from the database
            IEnumerable<Customer> customers = _dbContext.Customers;
            //Sending to the View as a Model
            return View(customers);
        }

        //Create
        //We don't need any other info to make a customer. Other tables it will be more difficult
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer model)
        {
            //Check if model is valid
            if (!ModelState.IsValid)
            {
                //send them back to view if server side validation fails
                return View(model);
            }
            //Add to database
            //we dont need to have the <Customer> below
            _dbContext.Add<Customer>(model);
            //save the changes
            _dbContext.SaveChanges();
            //Where to go after creating the New Customer
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int ID)
        {
            //Check and make sure an id came in
            if(ID == 0)
            {
                //send 404 if no id came in
                return NotFound();
            }
            //get customer out of database
            Customer customer = _dbContext.Customers.SingleOrDefault(c => c.ID == ID);
            if(customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //The Harder Way, when the object posted back is not entity model, it will have a customer id
            //get the customer from the database that needs to be updated
            Customer cust = _dbContext.Customers.SingleOrDefault(c => c.ID == model.ID);
            //update the properties
            cust.FirstName = model.FirstName;
            cust.LastName = model.LastName;
            cust.Phone = model.Phone;
            cust.Email = model.Email;
            cust.Mobile = model.Mobile;
            //update the database
            _dbContext.Update(cust);
            //save the changes to the database
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int ID)
        {
            if(ID == 0)
            {
                return NotFound();
            }
            //get teh customer out of the database
            Customer c = _dbContext.Customers.SingleOrDefault(c => c.ID == ID);
            if(c == null)
            {
                return NotFound();
            }
            return View(c);
        }
    }
}

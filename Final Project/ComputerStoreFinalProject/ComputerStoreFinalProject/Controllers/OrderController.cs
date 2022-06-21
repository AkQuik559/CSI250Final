using ComputerStoreFinalProject.Data;
using ComputerStoreFinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ComputerStoreFinalProject.Controllers
{
    public class OrderController : Controller
    {
        //Properties
        private ComputerStoreDbContext _context;
        //Constructor
        public OrderController(ComputerStoreDbContext context)
        {
            _context = context;
        }
        //Create an Order, we need a customerID to do this
        //Make sure you remember the ID you are talking about
        [HttpGet]
        public IActionResult Create(int customerID)
        {
            if(customerID == 0)
            {
                return NotFound();
            }
            Customer c = _context.Customers.SingleOrDefault(x => x.ID == customerID);
            if(c == null)
            {
                return NotFound();
            }
            Order model = new Order
            {
                CustomerID = customerID,
                OrderDate = System.DateTime.Today,
                Customer = c
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Order model)
        {
            if (!ModelState.IsValid)
            {
                model.Customer = _context.Customers.SingleOrDefault(x => x.ID == model.CustomerID);
                //send them back to the view 
                return View(model);
            }
            //
            _context.Orders.Add(model);
            _context.SaveChanges();
            //model.ID = 2;
            //Send this ID to an endpoint in a different controller
            return RedirectToAction("Create", "ComputerInvoice", new { orderID = model.ID });
        }
    }
}

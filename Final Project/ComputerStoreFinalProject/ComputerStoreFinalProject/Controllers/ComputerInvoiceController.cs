using ComputerStoreFinalProject.Data;
using ComputerStoreFinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ComputerStoreFinalProject.Controllers
{
    public class ComputerInvoiceController : Controller
    {
        private ComputerStoreDbContext _context;

        public ComputerInvoiceController(ComputerStoreDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Create(int orderID)
        {
            if(orderID == 0)
            {
                return NotFound();
            }
            //Get the order and include both the customer and the ComputerOrders
            Order order = _context.Orders.Include(x => x.Customer).Include(x => x.ComputerOrder).SingleOrDefault(x => x.ID == orderID);
            //This page also needs all of the ComputerOrders
            IEnumerable<SelectListItem> Computer = _context.Computers.Select(x => new SelectListItem
            {
                Text = x.CompanyName,
                Value = x.ID.ToString()
            });
            //pass the SelectList in the viewbag
            ViewBag.Computers = Computer;
            //Create a new ComputerOrder
            ComputerOrder CO = new ComputerOrder
            {
                OrderID = orderID,
                Order = order
            };
            return View(CO);
        }
        [HttpPost]
        public IActionResult Create(ComputerOrder model)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<SelectListItem> Computer = _context.Computers.Select(x => new SelectListItem
                {
                    Text = x.CompanyName,
                    Value = x.ID.ToString()
                });
                //pass the SelectList in the viewbag
                ViewBag.Computers = Computer;
                model.Order = _context.Orders.Include(x => x.Customer).Include(x => x.ComputerOrder).SingleOrDefault(x => x.ID == model.OrderID);
            }
            _context.ComputerOrders.Add(model);
            _context.SaveChanges();
            //redirct to an action that allows them to add additional items
            return RedirectToAction("AddAdditional", new { orderID = model.OrderID });
        }
    }
}

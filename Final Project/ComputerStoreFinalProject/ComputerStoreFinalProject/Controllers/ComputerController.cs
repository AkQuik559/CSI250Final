using ComputerStoreFinalProject.Data;
using ComputerStoreFinalProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ComputerStoreFinalProject.Controllers
{
    public class ComputerController : Controller
    {
        private ComputerStoreDbContext _context;
        //The WebHostEnvironment congtains info about where the project is hosted (URL or Address to location),
        //Am I in Developer vs Deployment Mode and can be injected into any controller where it is needed
        IWebHostEnvironment _env;

        public ComputerController(ComputerStoreDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            IEnumerable<Computer> computers = _context.Computers;
            return View(computers);
        }
        //Create a Computer
        [HttpGet]
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ComputerVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //Now down here the model passed
            //Put all user uploaded images into a folder called Images
            string fileName = SaveUploadedFile(model);
            //now we are ready to make a new Computer and add to database
            Computer c = new Computer()
            {
                CompanyName = model.CompanyName,
                ComputerModel = model.ComputerModel,
                Year = model.Year,
                Price = model.Price,
                ProductImage = fileName
            };
            _context.Computers.Add(c);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        //Edit
        [HttpGet]
        public IActionResult Edit(int ID)
        {
            //Check and make sure an id came in
            if (ID == 0)
            {
                //send 404 if no id came in
                return NotFound();
            }
            //get customer out of database
            Computer computer = _context.Computers.SingleOrDefault(x => x.ID == ID);
            if (computer == null)
            {
                return NotFound();
            }
            return View(computer);
        }
        [HttpPost]
        public IActionResult Edit(Computer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //The Harder Way, when the object posted back is not entity model, it will have a customer id
            //get the customer from the database that needs to be updated
            Computer comp = _context.Computers.SingleOrDefault(c => c.ID == model.ID);
            //update the properties
            comp.CompanyName = model.CompanyName;
            comp.ComputerModel = model.ComputerModel;
            comp.Year = model.Year;
            comp.Price = model.Price;
            comp.ProductImage = model.ProductImage;
            //update the database
            _context.Update(comp);
            //save the changes to the database
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Details
        public IActionResult Details(int ID)
        {
            if (ID == 0)
            {
                return NotFound();
            }
            //get teh customer out of the database
            Computer com = _context.Computers.SingleOrDefault(c => c.ID == ID);
            if (com == null)
            {
                return NotFound();
            }
            return View(com);
        }
        //Delete
        [HttpGet]
        public IActionResult Delete(int ID)
        {
            Computer computer = _context.Computers.SingleOrDefault(c => c.ID == ID);
            if(computer == null)
            {
                return NotFound();
            }
            return View(computer);
        }
        [HttpPost]
        public IActionResult Delete(Computer computer)
        {
            computer = _context.Computers.SingleOrDefault(c => c.ID == computer.ID);
            if(computer == null)
            {
                return NotFound();
            }
            _context.Computers.Remove(computer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Method takes ComputerVM, gives the image  a random name
        //saves the image and returns the filename as a string
        private string SaveUploadedFile(ComputerVM model)
        {
            string fileName = "";
            if(model.ProductImageFile != null)
            {
                string folder = Path.Combine(_env.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ProductImageFile.FileName);
                string filePath = Path.Combine(folder, fileName);
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    model.ProductImageFile.CopyTo(fs);
                }
            }
            return fileName;
        }
    }
}

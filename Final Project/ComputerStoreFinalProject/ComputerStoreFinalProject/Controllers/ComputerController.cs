using ComputerStoreFinalProject.Data;
using ComputerStoreFinalProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace ComputerStoreFinalProject.Controllers
{
    public class ComputerController : Controller
    {
        ComputerStoreDbContext _context;
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

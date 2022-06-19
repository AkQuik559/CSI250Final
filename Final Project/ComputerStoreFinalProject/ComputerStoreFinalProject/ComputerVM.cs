using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStoreFinalProject
{
    public class ComputerVM
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Computer Model")]
        public string ComputerModel { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; }

        //Navigation properties
        //Each product has a collection of ComputerOrders associated with it

        //Property to store the filename of a product image
        //This is the string that shows
        public string ProductImageString { get; set; } 
        //Set this file to take in only Images
        [Required]
        [FileExtensions(Extensions = ".jpg,.png,.jpeg", ErrorMessage = "Images only")]
        //This is the actual picture of the computer
        public IFormFile ProductImageFile { get; set; }
    }
}

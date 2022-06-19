using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStoreFinalProject.Models
{
    public class Computer
    {
        [Key]
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
        public string ProductImage { get; set; }
        public ICollection<ComputerOrder> ComputerOrder { get; set; }

    }
}

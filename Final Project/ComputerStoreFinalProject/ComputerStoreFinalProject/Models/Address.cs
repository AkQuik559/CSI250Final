using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStoreFinalProject.Models
{
    public class Address
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Street Number")]
        public string StreetNumber { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }
        public string Unit { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(20)]
        public string Zip { get; set; }
        [Required]
        [StringLength(100)]
        public string Country { get; set; }
        public int CustomerID { get; set; }

        [ForeignKey(nameof(CustomerID))]
        [InverseProperty("Address")]
        public  Customer Customer { get; set; }
    }
}

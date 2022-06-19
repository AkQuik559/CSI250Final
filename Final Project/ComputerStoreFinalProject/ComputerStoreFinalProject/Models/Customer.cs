using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStoreFinalProject.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        public string Mobile { get; set; }

        //Navigation Properties
        //List<Order> when we have multiples orders for a customer
        //There is no Column in SQL table called Orders. Thats now how we do things in SQL
        public ICollection<Order> Orders { get; set; }

        
        [InverseProperty("Customer")]
        public virtual ICollection<Address> Address { get; set; }

    }
}

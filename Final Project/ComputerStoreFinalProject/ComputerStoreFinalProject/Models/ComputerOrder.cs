using System.ComponentModel.DataAnnotations;

namespace ComputerStoreFinalProject.Models
{
    //This is the Bridge table. Helps with many computers ordered by one 1 customer or many orders by 1 customer.
    public class ComputerOrder
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int ComputerID { get; set; }
        public int OrderID { get; set; }

        //public int AddressID { get; set; }

        //Navigation Properties
        //Wires this up with one computer and one order
        public Order Order { get; set; }
        public Computer Computer { get; set; }

        //public Address Address { get; set; }
    }
}

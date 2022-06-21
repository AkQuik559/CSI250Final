using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStoreFinalProject.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }


        //Navigation Properties
        //Lets us get into our customer class using .Customer
        //Each order has 1 Customer
        public Customer Customer { get; set; }
        //Each order has a collection of the bridge table
        public ICollection<ComputerOrder> ComputerOrder { get; set; }
    }
}

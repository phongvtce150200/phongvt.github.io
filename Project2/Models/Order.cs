using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [Column(Order = 0)]
        public int OrderId { get; set; }
        public string Id { get; set; }
        
        [ForeignKey("OrderId")]
        public OrderDetails OrderDetails {get; set;}
        [ForeignKey("Id")]
        public User User { get; set; }
    }
}

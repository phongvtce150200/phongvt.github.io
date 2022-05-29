using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        [Key]
        public int OrderId { get; set; }
        public string Id { get; set; }
        public int PaymentId { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        [ForeignKey("OrderId")]
        public Order order { get; set;}
        [ForeignKey("Id")]
        public User Users { get; set; }
        [ForeignKey("PaymentId")]
        public Payment Payment { get; set; }
    }
}

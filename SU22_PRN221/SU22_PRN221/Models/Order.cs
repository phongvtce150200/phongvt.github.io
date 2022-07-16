using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SU22_PRN221.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string Id { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime ShippedDate { get; set; } = DateTime.Now;
        public float Vourcher { get; set; }
        [Required]
        [Column(TypeName = "Money")]
        public decimal Freight { get; set; }
        [Required]
        public string ShipAddress { get; set; }
        [Required]
        [Column(TypeName = "Money")]
        public decimal Money { get; set; }
        public bool OrderStatus { get; set; }
        [ForeignKey("Id")]
        public User User { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}

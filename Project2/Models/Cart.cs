using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        [Column(Order = 0)]
        public int CartId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int ProductId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string Id { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [ForeignKey("Id")]
        public User User { get; set; }
    }
}
